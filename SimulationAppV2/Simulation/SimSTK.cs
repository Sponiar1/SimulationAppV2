﻿using SimulationAppV2.Generator;
using SimulationAppV2.Simulation.Event.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationAppV2.Simulation.SimObject.STK;
using SimulationAppV2.Statistics;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using OSPStat;

namespace SimulationAppV2.Simulation
{
    internal class SimSTK : SimEventCore
    {
        #region Generators
        Random seedGen = new Random();
        Probability arrivalProb;
        Probability shopParkingProb;
        Probability paymentProb;

        Random carType;
        Probability personalCarProb;
        Empiric vanProb;
        Empiric truckProb;
        #endregion

        #region Staff and Customers 
        public int NumberOfCashier { get; set; } = 10;
        public int NumberOfTechnicians { get; set; } = 20;
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
        public Queue<CustomerSTK> Customers { get { return customers; } }
        Queue<CustomerSTK> paymentQueue = new Queue<CustomerSTK>(); //rada na zaplatenie po kontrole
        public Queue<CustomerSTK> PaymentQueue { get { return paymentQueue; } }
        Queue<CustomerSTK> controlWaiting = new Queue<CustomerSTK>(); // rada na kontrolu
        public Queue<CustomerSTK> ControlWaiting { get { return controlWaiting; } }
        public int AvailableSpots { get; set; } //rezervácia pre check-in
        #endregion

        #region Statistics
        public Average AverageTimeInSystem { get; set; }
        public Average GlobalAverageTimeInSystem { get; set; }
        public int Arrived { get; set; }
        public Average GlobalAverageVisits { get; set; }
        public int Left { get; set; }
        public Average GlobalLeftInSystem { get; set; }
        public Average TakeOverWaiting { get; set; }
        public Average GlobalTakeOverWaiting { get; set; }
        public WeightedAverage AveragePeopleInSystem { get; set; }
        public Average GlobalAveragePeopleInSystem { get; set; }

        public WeightedAverage AverageFreeCashier { get; set; }
        public Average GlobalAverageFreeCashier { get; set; }

        public WeightedAverage AverageFreeTechnician { get; set; }
        public Average GlobalAverageFreeTechnician { get; set; }

        public WeightedAverage AveragePeopleWaitingForTakeOver { get; set; }
        public Average GlobalAveragePeopleWaitingForTakeOver { get; set; }

        public ConfidenceInterval CIAverageTimeInSystem { get; set; }
        public ConfidenceInterval CIAverageNumberOfCustomers { get; set; }

        public Average AveragePaymentWaiting { get; set; }
        public Average GlobalAveragePaymentWaiting { get; set; }
        public WeightedAverage AveragePaymentQueue { get; set; }
        public Average GlobalAveragePaymentQueue { get; set; }
        public WeightedAverage AverageControlQueue { get; set; }
        public Average GlobalAverageControlQueue { get; set; }
        public WeightedAverage AverageFreeSpots { get; set; }
        public Average GlobalAverageFreeSpots { get; set; }
        public Average AverageControlWaiting { get; set; }
        public Average GlobalAverageControlWaiting { get; set; }

        #endregion

        public STKDetails STKDetails { get; set; }

        public event EventHandler<SimulationDetailsEventArgs> SimulationDetails;
        public event EventHandler<GlobalDetailsEventArgs> GlobalDetails;
        public event EventHandler<AfterSimulationDetailsEventArgs> AfterSimulationDetails;
        public SimSTK()
        {
            STKDetails = new STKDetails();
            Turbo = false;
            Pause = false;
        }

        public override void BeforeSimulation()
        {
            #region Generators initialization
            arrivalProb = new Exponential(60.0 / 23.0, new Random(seedGen.Next()));
            shopParkingProb = new Triangular(180.0 / 60.0, 695.0 / 60.0, 431.0 / 60.0, new Random(seedGen.Next()));
            paymentProb = new Continuous(65d / 60d, 177d / 60d, new Random(seedGen.Next()));
            carType = new Random(seedGen.Next());
            personalCarProb = new Discrete(31, 45, new Random(seedGen.Next()));
            vanProb = new Empiric(STKDetails.VanTime, STKDetails.VanTimeProb, new Random(seedGen.Next()));
            truckProb = new Empiric(STKDetails.TruckTime, STKDetails.TruckTimeProb, new Random(seedGen.Next()));
            #endregion

            #region Global statistics initialization
            GlobalAverageTimeInSystem = new Average();
            GlobalAverageVisits = new Average();
            GlobalLeftInSystem = new Average();
            GlobalTakeOverWaiting = new Average();
            GlobalAveragePeopleInSystem = new Average();
            GlobalAverageFreeCashier = new Average();
            GlobalAverageFreeTechnician = new Average();
            GlobalAveragePeopleWaitingForTakeOver = new Average();
            CIAverageTimeInSystem = new ConfidenceInterval();
            CIAverageNumberOfCustomers = new ConfidenceInterval();

            GlobalAveragePaymentWaiting = new Average();
            GlobalAveragePaymentQueue = new Average();
            GlobalAverageFreeSpots = new Average();
            GlobalAverageControlQueue = new Average();
            GlobalAverageControlWaiting = new Average();
            #endregion
        }

        public override void BeforeReplication()
        {
            base.BeforeReplication();
            #region Local Statistics and variables initialization
            Arrived = 0;
            Left = 0;
            CurrentTime = STKDetails.Opening;
            MaxTime = STKDetails.Closing;
            AvailableSpots = 5;
            AverageTimeInSystem = new Average();
            TakeOverWaiting = new Average();
            AveragePeopleInSystem = new WeightedAverage(CurrentTime);
            AverageFreeCashier = new WeightedAverage(CurrentTime);
            AverageFreeTechnician = new WeightedAverage(CurrentTime);
            AveragePeopleWaitingForTakeOver = new WeightedAverage(CurrentTime);

            AveragePaymentWaiting = new Average();
            AveragePaymentQueue = new WeightedAverage(CurrentTime);
            AverageControlQueue = new WeightedAverage(CurrentTime);
            AverageControlWaiting = new Average();
            AverageFreeSpots = new WeightedAverage(CurrentTime);
            #endregion

            #region StartingEvent
            Event.Event helpEvent;
            helpEvent = new ArrivalSTK(this, new CustomerSTK(this.GetCarType(), 1, CurrentTime));
            helpEvent.Time = CurrentTime;
            addEvent(helpEvent);
            #endregion

            #region Queues and arrays initialization
            Customers.Clear();
            ControlWaiting.Clear();
            PaymentQueue.Clear();
            CustomersInSystem.Clear();

            AvailableCashiers.Clear();
            AvailableTechnicians.Clear();
            cashiers = new CashierSTK[NumberOfCashier];
            for (int i = 0; i < cashiers.Length; i++)
            {
                cashiers[i] = new CashierSTK(i);
                AvailableCashiers.Enqueue(cashiers[i]);
            }
            technicians = new TechnicianSTK[NumberOfTechnicians];
            for (int i = 0; i < technicians.Length; i++)
            {
                technicians[i] = new TechnicianSTK(i);
                AvailableTechnicians.Enqueue(technicians[i]);
            }
            #endregion


        }

        public override void AfterReplication()
        {
            CurrentTime = STKDetails.Closing;
            #region Statistics of people left in system
            /*
            foreach (var customer in CustomersInSystem)
            {
                AverageTimeInSystem.Add(CurrentTime - customer.Value.Arrival);
            }*/
            foreach (var customer in Customers) 
            { 
                TakeOverWaiting.Add(CurrentTime - customer.Arrival);
            }
            AveragePeopleWaitingForTakeOver.Add(Customers.Count(), CurrentTime);
            AverageFreeTechnician.Add(AvailableTechnicians.Count(), CurrentTime);
            AverageFreeCashier.Add(AvailableCashiers.Count(), CurrentTime);
            AveragePeopleInSystem.Add(CustomersInSystem.Count(), CurrentTime);

            AveragePaymentQueue.Add(PaymentQueue.Count(), CurrentTime);
            foreach (var customer in PaymentQueue)
            {
                AveragePaymentWaiting.Add(CurrentTime - customer.WaitingStartAt);
            }
            foreach (var customer in ControlWaiting)
            {
                AverageControlWaiting.Add(CurrentTime - customer.WaitingStartAt);
            }
            AverageControlQueue.Add(controlWaiting.Count(), CurrentTime);
            AverageFreeSpots.Add(AvailableSpots, CurrentTime);
            #endregion
            #region Global statistics
            if (!base.CancellationToken.IsCancellationRequested)
            {
                GlobalAverageTimeInSystem.Add(AverageTimeInSystem.getActualAverage());
                GlobalAverageVisits.Add(Arrived);
                GlobalLeftInSystem.Add(Arrived - Left);
                GlobalTakeOverWaiting.Add(TakeOverWaiting.getActualAverage());
                CIAverageTimeInSystem.add(AverageTimeInSystem.getActualAverage());
                GlobalAveragePeopleInSystem.Add(AveragePeopleInSystem.getWeightedAverage());
                CIAverageNumberOfCustomers.add(AveragePeopleInSystem.getWeightedAverage());
                GlobalAverageFreeCashier.Add(AverageFreeCashier.getWeightedAverage());
                GlobalAverageFreeTechnician.Add(AverageFreeTechnician.getWeightedAverage());
                GlobalAveragePeopleWaitingForTakeOver.Add(AveragePeopleWaitingForTakeOver.getWeightedAverage());

                GlobalAveragePaymentQueue.Add(AveragePaymentQueue.getWeightedAverage());
                GlobalAveragePaymentWaiting.Add(AveragePaymentWaiting.getActualAverage());
                GlobalAverageControlQueue.Add(AverageControlQueue.getWeightedAverage());
                GlobalAverageControlWaiting.Add(AverageControlWaiting.getActualAverage());
                GlobalAverageFreeSpots.Add(AverageFreeSpots.getWeightedAverage());
            }
            #endregion
            if (!Turbo || ((ReplicationsDone+1) % (NumberOfReplications*0.01) == 0))
            {
                RefreshGlobalStatOnGui();
            }
        }

        public override void AfterSimulation()
        {
            double myStat = GlobalAveragePeopleInSystem.getActualAverage();
            AfterSimulationDetails?.Invoke(this, new AfterSimulationDetailsEventArgs(CIAverageTimeInSystem, CIAverageNumberOfCustomers));
            string nameOfFile = NumberOfCashier + "-" + NumberOfTechnicians + "-" + DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss");
            string filePath = Path.Combine(Application.StartupPath, nameOfFile);
            WriteToCsv(filePath);
        }

        public double GetArrivalTime()
        {
            return arrivalProb.getValue();
        }

        public double GetshopParkingTime()
        {
            return shopParkingProb.getValue();
        }

        public double GetshopPaymentTime()
        {
            return paymentProb.getValue();
        }

        public CarType GetCarType()
        {
            double p = carType.NextDouble();
            if (p <= 0.65)
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

        public double GetCarTime(CarType type)
        {
            switch (type)
            {
                case CarType.PersonalCar:
                    return personalCarProb.getValue();
                case CarType.Van:
                    return vanProb.getDiscreteEmpiricProbability();
                default:
                    return truckProb.getDiscreteEmpiricProbability();
            }
        }

        public void RefreshGlobalStatOnGui()
        {
            GlobalDetails?.Invoke(this, new GlobalDetailsEventArgs(GlobalAverageTimeInSystem.getActualAverage(),
                                                                    ReplicationsDone + 1,
                                                                    GlobalAverageVisits.getActualAverage(),
                                                                    GlobalLeftInSystem.getActualAverage(),
                                                                    GlobalTakeOverWaiting.getActualAverage(),
                                                                    GlobalAveragePeopleInSystem.getActualAverage(),
                                                                    GlobalAverageFreeCashier.getActualAverage(),
                                                                    GlobalAverageFreeTechnician.getActualAverage(),
                                                                    GlobalAveragePeopleWaitingForTakeOver.getActualAverage(),
                                                                    GlobalAveragePaymentWaiting.getActualAverage(),
                                                                    GlobalAveragePaymentQueue.getActualAverage(),
                                                                    GlobalAverageControlQueue.getActualAverage(),
                                                                    GlobalAverageControlWaiting.getActualAverage(),
                                                                    GlobalAverageFreeSpots.getActualAverage()
                                                                    ));
        }
        public override void RefreshGui()
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
                                                                    AverageTimeInSystem.getActualAverage(),
                                                                    TakeOverWaiting.getActualAverage(),
                                                                    AveragePeopleInSystem.getWeightedAverage(),
                                                                    AverageFreeCashier.getWeightedAverage(),
                                                                    AverageFreeTechnician.getWeightedAverage(),
                                                                    AveragePeopleWaitingForTakeOver.getWeightedAverage()
                                                                    //Arrived,
                                                                    //Left
                                                                    )) ; 
        }

        public void WriteToCsv(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write("Average daily visits;");
                writer.Write(GlobalAverageVisits.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average people left in system;");
                writer.Write(GlobalLeftInSystem.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average waiting for takeover;");
                writer.Write(GlobalTakeOverWaiting.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average takeover queue;");
                writer.Write(GlobalAveragePeopleWaitingForTakeOver.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average waiting for control;");
                writer.Write(GlobalAverageControlWaiting.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average control queue;");
                writer.Write(GlobalAverageControlQueue.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average empty spot;");
                writer.Write(GlobalAverageFreeSpots.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average payment waiting;");
                writer.Write(GlobalAveragePaymentWaiting.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average payment queue;");
                writer.Write(GlobalAveragePaymentQueue.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average free cashier;");
                writer.Write(GlobalAverageFreeCashier.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average free technician;");
                writer.Write(GlobalAverageFreeTechnician.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average customers in system;");
                writer.Write(GlobalAveragePeopleInSystem.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Confidence Interval for average customers in system;");
                writer.Write(CIAverageNumberOfCustomers.getLeftSideNinetyFive() + "," + CIAverageNumberOfCustomers.getRightSideNinetyFive());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Average time spent in system;");
                writer.Write(GlobalAverageTimeInSystem.getActualAverage());
                writer.Write(";");
                writer.WriteLine();
                writer.Write("Confidence Interval for average customers in system;");
                writer.Write(CIAverageTimeInSystem.getLeftSideNinety() + "," + CIAverageTimeInSystem.getRightSideNinety());
                writer.Write(";");
                writer.WriteLine();
            }
        }
    }

    internal class SimulationDetailsEventArgs : EventArgs
    {
        public double Time { get; }
        public int CheckInQueue { get; }
        public int InspectionParkingLot { get; }
        public int PaymentQueue { get; }
        public int FreeCashiers { get; }
        public int FreeTechnicians { get; }
        public TechnicianSTK[] Technicians { get; }
        public CashierSTK[] Cashier { get; }
        public Dictionary<int, CustomerSTK> customersInSystem { get; }
        public double AverageActual { get; }
        public double AverageTakeOverWaiting { get; }
        public double AveragePeopleInSystem { get; }
        public double AverageFreeCashiers { get; }
        public double AverageFreeTechnician { get; }
        public double AveragePeopleWaitingForTakeOver { get; }
        public SimulationDetailsEventArgs(double time, int checkInQueue, int inspectionParkingLot, int paymentQueue, int freeCashiers, int freeTechnician,
                                            TechnicianSTK[] technicians, CashierSTK[] cashier, Dictionary<int, CustomerSTK> customers, double averageActual,
                                            double averageTakeOverWaiting, double averagePeopleInSystem, double averageFreeCashiers, double averageFreeTechnician, 
                                            double averagePeopleWaitingForTakeOver)
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
            AverageTakeOverWaiting = averageTakeOverWaiting;
            AveragePeopleInSystem = averagePeopleInSystem;
            AverageFreeCashiers = averageFreeCashiers;
            AverageFreeTechnician = averageFreeTechnician;
            AveragePeopleWaitingForTakeOver = averagePeopleWaitingForTakeOver;
        }
    }

    internal class GlobalDetailsEventArgs : EventArgs
    {
        public double GlobalAverage { get; }
        public int NumberOfReplication { get; }
        public double GlobalVisits { get; }
        public double GlobalLeftInSystem { get; }
        public double GlobalTakeOverWaiting { get; }
        public double GlobalAveragePeopleInSystem { get; }
        public double GlobalAverageFreeCashiers { get; }
        public double GlobalAverageFreeTechnicians { get; }
        public double GlobalAveragePeopleWaitingForTakeOver { get; }

        public double GlobalAveragePaymentWaiting { get; }
        public double GlobalAveragePaymentQueue { get; }
        public double GlobalAverageControlQueue { get; }
        public double GlobalAverageControlWaiting { get; }
        public double GlobalAverageEmptySpots { get; }

        public GlobalDetailsEventArgs(double globalAverage,
                                      int numberOfReplication,
                                      double globalVisits,
                                      double globalLeftInSystem,
                                      double globalTakeOverWaiting,
                                      double globalAveragePeopleInSystem,
                                      double globalAverageFreeCashiers,
                                      double globalAverageFreeTechnicians,
                                      double globalAveragePeopleWaitingForTakeOver,
                                      double globalAveragePaymentWaiting,
                                      double globalAveragePaymentQueue,
                                      double globalAverageControlQueue,
                                      double globalAverageControlWaiting,
                                      double globalAverageEmptySpots)
        {
            NumberOfReplication = numberOfReplication;
            GlobalAverage = globalAverage;
            GlobalVisits = globalVisits;
            GlobalLeftInSystem = globalLeftInSystem;
            GlobalTakeOverWaiting = globalTakeOverWaiting;
            GlobalAveragePeopleInSystem = globalAveragePeopleInSystem;
            GlobalAverageFreeCashiers = globalAverageFreeCashiers;
            GlobalAverageFreeTechnicians = globalAverageFreeTechnicians;
            GlobalAveragePeopleWaitingForTakeOver = globalAveragePeopleWaitingForTakeOver;
            GlobalAveragePaymentWaiting = globalAveragePaymentWaiting;
            GlobalAveragePaymentQueue = globalAveragePaymentQueue;
            GlobalAverageControlQueue = globalAverageControlQueue;
            GlobalAverageControlWaiting = globalAverageControlWaiting;
            GlobalAverageEmptySpots = globalAverageEmptySpots;
        }
    }

    internal class AfterSimulationDetailsEventArgs : EventArgs
    {
        public double CITimeInSystemLeft { get; }
        public double CITimeInSystemRight { get; }
        public double CIAverageCustomersLeft { get; }
        public double CIAverageCustomersRight { get; }
        public AfterSimulationDetailsEventArgs(ConfidenceInterval confidenceTimeInSystem, ConfidenceInterval confidenceAverageCustomers)
        {
            confidenceTimeInSystem.setStandardDeviation();
            CITimeInSystemLeft = Math.Round(confidenceTimeInSystem.getLeftSideNinety(),6);
            CITimeInSystemRight = Math.Round(confidenceTimeInSystem.getRightSideNinety(),6);

            confidenceAverageCustomers.setStandardDeviation();
            CIAverageCustomersLeft = Math.Round(confidenceAverageCustomers.getLeftSideNinetyFive(), 6);
            CIAverageCustomersRight = Math.Round(confidenceAverageCustomers.getRightSideNinetyFive(), 6);
        }
    }
}
