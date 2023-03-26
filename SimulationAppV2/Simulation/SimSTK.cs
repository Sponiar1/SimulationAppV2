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

        Random carType;
        Probability personalCarProb;
        Empiric vanProb;
        Empiric truckProb;

        Queue<Customer> customers = new Queue<Customer>(); // rada na prevzatie
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
        public STKDetails STKDetails { get; set; }
        public SimSTK()
        {
            STKDetails = new STKDetails();
        }

        public override void BeforeSimulation()
        {
            arrivalProb = new Exponential(60 / 23, new Random(seedGen.Next()));
            shopParkingProb = new Triangular(180 / 60, 695 / 60, 431 / 60, new Random(seedGen.Next()));
            paymentProb = new Continuous(65, 177, new Random(seedGen.Next()));
            carType = new Random(seedGen.Next());
            personalCarProb = new Discrete(31, 45, new Random(seedGen.Next()));
            vanProb = new Empiric(STKDetails.VanTime, STKDetails.VanTimeProb, new Random(seedGen.Next()));
            truckProb = new Empiric(STKDetails.TruckTime, STKDetails.TruckTimeProb, new Random(seedGen.Next()));
            RefreshTime = 600;
            CurrentTime = STKDetails.Heating;
            MaxTime = STKDetails.Closing;
        }

        public override void BeforeReplication()
        {
            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new Customer());
            helpEvent.Time = CurrentTime;
            addEvent(helpEvent);
            Event.Event sysEvent = new SysEvent(this);
            sysEvent.Time = CurrentTime;
            addEvent(sysEvent);
            Cashiers = 5;
            Technicians = 10;
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
