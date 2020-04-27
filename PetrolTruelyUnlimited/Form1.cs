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


        string[] vehicleType = { "CAR->", "Van->", "HGV->" };
        string[] fuelType = { "Unleaded", "Diesel ", "LPG" };


        bool isWaiting = false;
        int objectIndex = 0;

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
                int randomNumber = random.Next(1500, 2201);

                vehicleTimer.Interval = 2500;

                int randomValue = random.Next(0, 3);
                vehicle[objectIndex] = new Vehicle(vehicleType[randomValue], fuelType[randomValue]);
                lab_Vehicle.Text = vehicleType[randomValue];
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
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;

                        case 2:
                            if (pump[1].getStatus() == true)
                            {
                                pump[1] = new Pump(pnl_Pump2);
                                VehicleStats.IncrementVehicleFueled();

                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 3:
                            if (pump[2].getStatus() == true)
                            {
                                pump[2] = new Pump(pnl_Pump3);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 4:
                            if (pump[3].getStatus() == true)
                            {
                                pump[3] = new Pump(pnl_Pump4);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 5:
                            if (pump[4].getStatus() == true)
                            {
                                pump[4] = new Pump(pnl_Pump5);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 6:
                            if (pump[5].getStatus() == true)
                            {
                                pump[5] = new Pump(pnl_Pump6);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 7:
                            if (pump[6].getStatus() == true)
                            {
                                pump[6] = new Pump(pnl_Pump7);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 8:
                            if (pump[7].getStatus() == true)
                            {
                                pump[7] = new Pump(pnl_Pump8);
                                VehicleStats.IncrementVehicleFueled();
                            }
                            else lab_Input.Text = "Pump " + pumpNo.ToString() + " Is Busy";
                            break;
                        case 9:
                            if (pump[8].getStatus() == true)
                            {
                                pump[8] = new Pump(pnl_Pump9);
                                VehicleStats.IncrementVehicleFueled();
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

        private void TestTimer_Tick(object sender, EventArgs e)
        {
            label12.Text = VehicleStats.getTotalVehicle().ToString();
            label13.Text = VehicleStats.getVehicleFueled().ToString();
            label14.Text = VehicleStats.getVehicleReturned().ToString();

        }
    }
}