using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolTruelyUnlimited
{
    class Transaction
    {
        private string vehicleType;
        private double numberOfLites;
        private int pumpNumber;

        public Transaction(string vehicleType, double numberOfLites, int pumpNumber)
        {
            this.vehicleType = vehicleType;
            this.numberOfLites = numberOfLites;
            this.pumpNumber = pumpNumber;
        }

        public string getVehicleType()
        {
            return vehicleType;
        }
        public double getNumberOFLiters()
        {
            return numberOfLites;
        }
        public int getPumpNumber()
        {
            return pumpNumber;
        }
      

    }
}
