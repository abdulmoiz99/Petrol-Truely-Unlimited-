using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolTruelyUnlimited
{
    public partial class Form1 : Form
    {
        Vehicle[] vehicle = new Vehicle[1000];
        Pump[] pump = new Pump[9];
        VehicleStats VehicleStats = new VehicleStats();
        Transaction transaction;

        const double COSTPERLITER = 110;

        string[] vehicleType = { "Car", "Van", "HGV" };
        string[] fuelType = { "Unleaded", "Diesel ", "LPG" };


        bool isWaiting = false;
        int objectIndex = 0;
        int intervalTime;

        public Form1()
        {
            InitializeComponent();
            lab_Vehicle.Text = "";
            for (int i = 0; i < pump.Length; i++)
            {
                pump[i] = new Pump();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void vehicleTimer_Tick(object sender, EventArgs e)
        {

            Random random = new Random();
            if (isWaiting == false)
            {
                intervalTime = random.Next(1500, 2201);

                vehicleTimer.Interval = intervalTime;

                int randomVehicle = random.Next(0, 3);
                int randomFuel = random.Next(0, 3);
                vehicle[objectIndex] = new Vehicle(vehicleType[randomVehicle], fuelType[randomFuel]);
                lab_TotalVehicles.Text = "Total Vehicles: " + VehicleStats.getTotalVehicle().ToString();
                lab_Vehicle.Text = vehicleType[randomVehicle];
                isWaiting = true;
                VehicleStats.IncrementTotalVehicle();
            }
            else
            {
                vehicleTimer.Interval = 1500;
                objectIndex++;
                isWaiting = false;
                lab_Vehicle.Text = "";
                VehicleStats.IncrementVehicleReturned();
                lab_VehiclesRetured.Text = "Vehicles Returned: " + VehicleStats.getVehicleReturned().ToString();
            }

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            lab_Input.Text = "";
            char input = e.KeyChar;

            if (char.IsDigit(input) && input != '0')
            {
                lab_Input.Text = input.ToString();

                int pumpNo = int.Parse(lab_Input.Text);
                if (isWaiting)
                {
                    isWaiting = false;
                    lab_Vehicle.Text = "";

                    switch (pumpNo)
                    {
                        case 1:
                            if (pump[0].getStatus() == true)
                            {
                                pump[0] = new Pump(pnl_Pump1);

                                CalculateDispension(0);
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;

                        case 2:
                            if (pump[1].getStatus() == true)
                            {
                                pump[1] = new Pump(pnl_Pump2);
                                CalculateDispension(1);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 3:
                            if (pump[2].getStatus() == true)
                            {
                                pump[2] = new Pump(pnl_Pump3);
                                CalculateDispension(2);
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 4:
                            if (pump[3].getStatus() == true)
                            {
                                pump[3] = new Pump(pnl_Pump4);
                                CalculateDispension(3);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 5:
                            if (pump[4].getStatus() == true)
                            {
                                pump[4] = new Pump(pnl_Pump5);
                                CalculateDispension(4);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 6:
                            if (pump[5].getStatus() == true)
                            {
                                pump[5] = new Pump(pnl_Pump6);
                                CalculateDispension(5);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 7:
                            if (pump[6].getStatus() == true)
                            {
                                pump[6] = new Pump(pnl_Pump7);
                                CalculateDispension(6);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 8:
                            if (pump[7].getStatus() == true)
                            {
                                pump[7] = new Pump(pnl_Pump8);
                                CalculateDispension(7);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 9:
                            if (pump[8].getStatus() == true)
                            {
                                pump[8] = new Pump(pnl_Pump9);
                                CalculateDispension(8);

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;

                        default:
                            break;
                    }
                }
                else lab_Input.Text = "No Vehicle In Waitng";
            }
        }

        private void CalculateDispension(int index)
        {

            VehicleStats.IncrementVehicleFueled();
            lab_VehiclesFueled.Text = "Vehicles Fueled: " + VehicleStats.getVehicleFueled().ToString();

            if (vehicle[objectIndex].getFuelType() == "Unleaded")
            {
                PumpStats.IncrementliterDispensed(pump[index].getFuelIntervalTime());
                pump[index].AddUnleadedDispensed(PumpStats.getLiterDispensed());
            }
            else if (vehicle[objectIndex].getFuelType() == "Diesel")
            {
                PumpStats.IncrementliterDispensed(pump[index].getFuelIntervalTime());
                pump[index].AddDieselDispensed(PumpStats.getLiterDispensed());
            }
            else
            {
                PumpStats.IncrementliterDispensed(pump[index].getFuelIntervalTime());
                pump[index].AddLPGDispensed(PumpStats.getLiterDispensed());
            }
            transaction = new Transaction(vehicle[objectIndex].getVehicleType(), PumpStats.getLiterDispensed(), index + 1);
            AddTransactionToList();
            lab_TotalFuelDispensed.Text = "Total Fuel Dispensed: " + PumpStats.getTotalliterDispensed();
            lab_TotalAmount.Text = "Total Amount: " + PumpStats.getTotalliterDispensed() * COSTPERLITER;
            lab_commission.Text = "1% commission: " + PumpStats.getTotalliterDispensed() * COSTPERLITER * 0.01;
        }

        private void AddTransactionToList()
        {
            string[] row = { transaction.getVehicleType(), transaction.getNumberOFLiters().ToString(), transaction.getPumpNumber().ToString() };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }



        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }


    }
}