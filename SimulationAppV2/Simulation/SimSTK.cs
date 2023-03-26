using SimulationAppV2.Generator;
using SimulationAppV2.Simulation.SimObject;
using SimulationAppV2.Simulation.Event.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimSTK : SimEventCore
    {
        Random seedGen = new Random();
        Probability arrivalProb;
        Probability shopParkingProb;
        Probability paymentProb;
        double opening = 9 * 60;
        double closing = 17 * 60;
        double stopAccepting = 15 * 60 + 45;
        double heating = 8 * 60;
        Random carType;
        Probability personalCarProb;
        Empiric vanProb;
        int[] vanTime = { 35, 37, 38, 40, 41, 47, 48, 52 };
        double[] vanTimeProb = { 0.2, 0.35, 0.3, 0.15 };
        Empiric truckProb;
        int[] truckTime = { 37, 42, 43, 45, 46, 47, 48, 51, 52, 55, 56, 65 };
        double[] truckTimeProb = { 0.05, 0.1, 0.15, 0.4, 0.25, 0.05 };
        //Queue<int> cashiers = new Queue<int>();
        Queue<Customer> customers = new Queue<Customer>(); // rada na prevzatie
        //Queue<int> technicians = new Queue<int>();
        Queue<Customer> paymentQueue = new Queue<Customer>(); //rada na zaplatenie po kontrole
        Queue<Customer> controlWaiting = new Queue<Customer>(); // rada na kontrolu
        public int Cashiers { get; set; } //pracovnici 1
        public int Technicians { get; set; } //pracovnici 2
        public Queue<Customer> Customers
        {
            get { return customers; }
        }
        public Queue<Customer> PaymentQueue
        {
            get { return paymentQueue; }
        }
        public Queue<Customer> ControlWaiting
        {
            get { return controlWaiting; }
        }
        public double RefreshTime { get; set; }
        public SimSTK()
        {
            
        }

        public override void BeforeSimulation()
        {
            arrivalProb = new Exponential(60 / 23, new Random(seedGen.Next()));
            shopParkingProb = new Triangular(180, 695, 431, new Random(seedGen.Next()));
            paymentProb = new Continuous(65, 177, new Random(seedGen.Next()));
            carType = new Random(seedGen.Next());
            personalCarProb = new Discrete(31, 45, new Random(seedGen.Next()));
            vanProb = new Empiric(vanTime, vanTimeProb, new Random(seedGen.Next()));
            truckProb = new Empiric(truckTime, truckTimeProb, new Random(seedGen.Next()));
            RefreshTime = 600;
        }

        public override void BeforeReplication()
        {
            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new Customer());
            helpEvent.Time = 0;
            addEvent(helpEvent);
        }

        public void addCustomerToQueue(Customer customer)
        {
            customers.Enqueue(customer);
        }

        public void addCustomerToPayment(Customer customer)
        {
            paymentQueue.Enqueue(customer);
        }
        public void addCustomerToControl(Customer customer)
        {
            controlWaiting.Enqueue(customer);
        }
        public Customer getCustomerFromQueue()
        {
            return customers.Dequeue();
        }
        
        public double getArrivalTime()
        {
            return arrivalProb.getValue();
        }

        public double getshopParkingTime()
        {
            return shopParkingProb.getValue();
        }

        public double getshopPaymentTime()
        {
            return paymentProb.getValue();
        }

        public double getPersonalCarTime()
        {
            return personalCarProb.getValue();
        }

        public double getVanTime()
        {
            return vanProb.getDiscreteEmpiricProbability();
        }

        public double getTruckTime()
        {
            return truckProb.getDiscreteEmpiricProbability();
        }

        public double getCarType() 
        {
            double p = carType.NextDouble();
            if(p <= 0.65) 
            { 
                return getPersonalCarTime();
            }
            else if (p <= 0.86)
            {
                return getVanTime();
            }
            else
            {
                return getTruckTime();
            }
        }
    }
}
