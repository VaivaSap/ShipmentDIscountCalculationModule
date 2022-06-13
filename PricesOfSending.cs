using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_ShipmentDiscountCalculationModule
{
    public class PricesOfSending
    {

        public static Dictionary<Size, double> LPPrices = new Dictionary<Size, double>()
        {

            { Size.S, 1.50 },
            { Size.M, 4.90 },
            { Size.L, 6.90 },

        };



        public static Dictionary<Size, double> MRPrices = new Dictionary<Size, double>()
        {
            { Size.S, 2.00 },
            { Size.M, 3.00 },
            { Size.L, 4.00 },
        };

        public static double GetPrice(Courier courier, Size size)
        {


            if (courier == Courier.LP)
            {
                return LPPrices[size];
               
            }

            else 
            {
                return MRPrices[size];
            }

        }

    }
}




