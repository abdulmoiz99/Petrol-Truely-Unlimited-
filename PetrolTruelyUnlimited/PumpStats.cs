using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolTruelyUnlimited
{
    class PumpStats
    {
        private static double literDispensed = 0;

        public void IncrementliterDispensed(int milliseconds)
        {
            literDispensed += Convert.ToDouble(milliseconds)*0.0015 ;

            //Formula: (milliseconds / 1000)*1.5 
        }
    }
}
