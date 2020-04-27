using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolTruelyUnlimited
{
    class VehicleStats
    {
        private static int TotalVehicle =0 ;
        private static int VehicleReturned = 0;
        private static int VehicleFueled = 0;
        
        public void IncrementTotalVehicle()
        {
            TotalVehicle++;
        }
        public void IncrementVehicleReturned()
        {
            VehicleReturned++;
        }
        public void IncrementVehicleFueled()
        {
            VehicleFueled++;
        }
        public int getTotalVehicle()
        {
            return TotalVehicle;
        }
        public int getVehicleReturned()
        {
            return VehicleReturned;
        }

        public int getVehicleFueled()
        {
            return VehicleFueled;
        }


    }
}
