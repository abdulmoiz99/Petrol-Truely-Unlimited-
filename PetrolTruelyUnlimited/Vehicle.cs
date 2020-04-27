using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolTruelyUnlimited
{
    class Vehicle
    {
        static int vehicleCreated = 0;
        public static bool isWaiting = false;
        public bool isServed { get;  set; }
        public string fuelType { get; set; }
        //Unleaded, Diesel and LPG
        public string vehicleType { get; set; }
        //car.van,hgv
        public Vehicle()
        {

        }
        public Vehicle(string vehicleType, string fuelType)
        {
            this.vehicleType = vehicleType;
            this.fuelType = fuelType;
            vehicleCreated++;
            isServed = false;
        }
        void VehicleReturn()
        {
            isWaiting = true;
        }

    }
}
