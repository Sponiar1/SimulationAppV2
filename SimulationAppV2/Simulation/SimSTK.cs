using SimulationAppV2.Generator;
using SimulationAppV2.Simulation.Event.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationAppV2.Simulation.SimObject.STK;
using SimulationAppV2.Statistics;

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

        CashierSTK[] cashiers;
        public CashierSTK[] Cashiers { get { return cashiers; } }
        Queue<CashierSTK> cashiersQueue = new Queue<CashierSTK>(); // zrušiť int a pýtať queue size
        public Queue<CashierSTK> AvailableCashiers { get { return cashiersQueue; } }

        TechnicianSTK[] technicians;
        public TechnicianSTK[] Technicians { get { return technicians; } }
        Queue<TechnicianSTK> technicianQueue = new Queue<TechnicianSTK>();
        public Queue<TechnicianSTK> AvailableTechnicians { get { return technicianQueue; } }

        Dictionary<int, CustomerSTK> customersInSystem = new Dictionary<int, CustomerSTK>();
        public Dictionary<int, CustomerSTK> CustomersInSystem { get { return customersInSystem; } }

        Queue<CustomerSTK> customers = new Queue<CustomerSTK>(); // rada na prevzatie
        Queue<CustomerSTK> paymentQueue = new Queue<CustomerSTK>(); //rada na zaplatenie po kontrole
        Queue<CustomerSTK> controlWaiting = new Queue<CustomerSTK>(); // rada na kontrolu
        public int AvailableSpots { get; set; } //rezervácia pre check-in
        //public int AvailableCashiers { get; set; } //pracovnici 1
        public Queue<CustomerSTK> Customers
        {
            get { return customers; }
        }
        public Queue<CustomerSTK> PaymentQueue
        {
            get { return paymentQueue; }
        }
        public Queue<CustomerSTK> ControlWaiting
        {
            get { return controlWaiting; }
        }
        public STKDetails STKDetails { get; set; }

        public Average AverageTimeInSystem { get; set; }

        public event EventHandler<SimulationDetailsEventArgs> SimulationDetails;
        public SimSTK()
        {
            STKDetails = new STKDetails();
            Turbo = false;
            Pause = false;
        }

        public override void BeforeSimulation()
        {
            arrivalProb = new Exponential(60 / 23, new Random(seedGen.Next()));
            shopParkingProb = new Triangular(180 / 60, 695 / 60, 431 / 60, new Random(seedGen.Next()));
            paymentProb = new Continuous(65 / 60, 177 / 60, new Random(seedGen.Next()));
            carType = new Random(seedGen.Next());
            personalCarProb = new Discrete(31, 45, new Random(seedGen.Next()));
            vanProb = new Empiric(STKDetails.VanTime, STKDetails.VanTimeProb, new Random(seedGen.Next()));
            truckProb = new Empiric(STKDetails.TruckTime, STKDetails.TruckTimeProb, new Random(seedGen.Next()));
            RefreshTime = 10;
            CurrentTime = STKDetails.Opening;
            MaxTime = STKDetails.Closing;
            int pokladnici = 6;  //7
            int technici = 22; //10 blizko
            cashiers = new CashierSTK[pokladnici];
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new CashierSTK(i);
                AvailableCashiers.Enqueue(cashiers[i]);
            }
            technicians = new TechnicianSTK[technici];
            for ( int i = 0;i < technicians.Length;i++)
            {
                technicians[i] = new TechnicianSTK(i);
                AvailableTechnicians.Enqueue(technicians[i]);
            }
        }

        public override void BeforeReplication()
        {
            AverageTimeInSystem = new Average();

            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new CustomerSTK(this.getCarType(), 1, CurrentTime));
            helpEvent.Time = CurrentTime;
            addEvent(helpEvent);
            
            //AvailableCashiers = 10;  //7
            //AvailableTechnicians = 20; //10 blizko
            AvailableSpots = 5;
            Customers.Clear();
            ControlWaiting.Clear();
            PaymentQueue.Clear();
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

        public CarType getCarType() 
        {
            double p = carType.NextDouble();
            if(p <= 0.65) 
            {
                return CarType.PersonalCar;
            }
            else if (p <= 0.86)
            {
                return CarType.Van;
            }
            else
            {
                return CarType.Truck;
            }
        }

        public double getCarTime(CarType type)
        {
            switch(type) 
            {
                case CarType.PersonalCar: 
                    return personalCarProb.getValue();
                case CarType.Van: 
                    return vanProb.getDiscreteEmpiricProbability();
                default:
                    return truckProb.getDiscreteEmpiricProbability();
            }
        }
        public override void refreshGui()
        {
            SimulationDetails?.Invoke(this, new SimulationDetailsEventArgs(this.CurrentTime,
                                                                    Customers.Count(),
                                                                    ControlWaiting.Count(),
                                                                    PaymentQueue.Count(),
                                                                    AvailableCashiers.Count(),
                                                                    AvailableTechnicians.Count(),
                                                                    Technicians,
                                                                    Cashiers,
                                                                    CustomersInSystem,
                                                                    AverageTimeInSystem.getActualAverage()
                                                                    //Arrived,
                                                                    //Left
                                                                    ));
        }
    }

    internal class SimulationDetailsEventArgs : EventArgs
    {
        public double Time { get; set; }
        public int CheckInQueue { get; set; }
        public int InspectionParkingLot { get; set; }
        public int PaymentQueue { get; set; }
        public int FreeCashiers { get; set; }
        public int FreeTechnicians { get; set; }
        public TechnicianSTK[] Technicians { get; }
        public CashierSTK[] Cashier { get; }
        public Dictionary<int, CustomerSTK> customersInSystem { get; }
        public double AverageActual { get; }
        public SimulationDetailsEventArgs(double time, int checkInQueue, int inspectionParkingLot, int paymentQueue, int freeCashiers, int freeTechnician, 
                                            TechnicianSTK[] technicians, CashierSTK[] cashier, Dictionary<int, CustomerSTK> customers, double averageActual)
        {
            Time = time;
            CheckInQueue = checkInQueue;
            InspectionParkingLot = inspectionParkingLot;
            PaymentQueue = paymentQueue;
            FreeCashiers = freeCashiers;
            FreeTechnicians = freeTechnician;
            Technicians = technicians;
            Cashier = cashier;
            this.customersInSystem = customers;
            AverageActual = averageActual;
        }
    }
}
