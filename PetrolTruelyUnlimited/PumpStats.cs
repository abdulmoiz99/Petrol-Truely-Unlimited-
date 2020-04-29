using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolTruelyUnlimited
{
    class PumpStats
    {
        private static double TotalliterDispensed = 0;

        private static double literDispensed = 0;
        public static void IncrementliterDispensed(int milliseconds)
        {
            literDispensed = Convert.ToDouble(milliseconds) * 0.0015;
            TotalliterDispensed += literDispensed;
            //Formula: (milliseconds / 1000)*1.5 
        }
        public static double getTotalliterDispensed()
        {
            return TotalliterDispensed;
        }
        public static double getLiterDispensed()
        {
            return literDispensed;
        }


    }
}
