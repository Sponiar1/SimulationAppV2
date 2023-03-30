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

        Queue<CustomerSTK> customers = new Queue<CustomerSTK>(); // rada na prevzatie
        Queue<CustomerSTK> paymentQueue = new Queue<CustomerSTK>(); //rada na zaplatenie po kontrole
        Queue<CustomerSTK> controlWaiting = new Queue<CustomerSTK>(); // rada na kontrolu
        public int AvailableSpots { get; set; } //rezervácia pre check-in
        public int Cashiers { get; set; } //pracovnici 1
        public int Technicians { get; set; } //pracovnici 2
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
        public double RefreshTime { get; set; }
        public int Arrived { get; set; }
        public int Left { get; set; }
        public STKDetails STKDetails { get; set; }

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
            CurrentTime = STKDetails.Heating;
            MaxTime = STKDetails.Closing;
        }

        public override void BeforeReplication()
        {
            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new CustomerSTK(this.getCarType()));
            helpEvent.Time = CurrentTime;
            addEvent(helpEvent);
            Event.Event sysEvent = new SysEvent(this);
            sysEvent.Time = CurrentTime;
            addEvent(sysEvent);
            Cashiers = 10;  //7
            Technicians = 20; //10 blizko
            AvailableSpots = 5;
            Arrived = 0;
            Left = 0;
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
                                                                    Cashiers,
                                                                    Technicians
                                                                    //Arrived,
                                                                    //Left
                                                                    ));
        }
    }

    public class SimulationDetailsEventArgs : EventArgs
    {
        public double Time { get; set; }
        public int CheckInQueue { get; set; }
        public int InspectionParkingLot { get; set; }
        public int PaymentQueue { get; set; }
        public int FreeCashiers { get; set; }
        public int FreeTechnicians { get; set; }
        public SimulationDetailsEventArgs(double time, int checkInQueue, int inspectionParkingLot, int paymentQueue, int freeCashiers, int freeTechnician)
        {
            Time = time;
            CheckInQueue = checkInQueue;
            InspectionParkingLot = inspectionParkingLot;
            PaymentQueue = paymentQueue;
            FreeCashiers = freeCashiers;
            FreeTechnicians = freeTechnician;
        }
    }
}
