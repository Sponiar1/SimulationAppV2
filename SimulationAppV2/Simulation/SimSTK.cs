using SimulationAppV2.Generator;
using SimulationAppV2.Simulation.Event.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationAppV2.Simulation.SimObject.STK;

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
        Queue<CustomerSTK> customers = new Queue<CustomerSTK>(); // rada na prevzatie
        Queue<CustomerSTK> paymentQueue = new Queue<CustomerSTK>(); //rada na zaplatenie po kontrole
        Queue<CustomerSTK> controlWaiting = new Queue<CustomerSTK>(); // rada na kontrolu
        public int AvailableSpots { get; set; } //rezervácia pre check-in
        public int AvailableCashiers { get; set; } //pracovnici 1
        public int AvailableTechnicians { get; set; } //pracovnici 2
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
            AvailableCashiers = 10;  //7
            AvailableTechnicians = 20; //10 blizko
            cashiers = new CashierSTK[AvailableCashiers];
        }

        public override void BeforeReplication()
        {
            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new CustomerSTK(this.getCarType()));
            helpEvent.Time = CurrentTime;
            addEvent(helpEvent);
            
            AvailableCashiers = 10;  //7
            AvailableTechnicians = 20; //10 blizko
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
                                                                    AvailableCashiers,
                                                                    AvailableTechnicians
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
