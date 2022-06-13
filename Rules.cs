using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_ShipmentDiscountCalculationModule
{
    public class Rules
    {

        public static Courier GetCourier(Size size)
        {

            if (PricesOfSending.LPPrices[Size.S] < PricesOfSending.MRPrices[Size.S])
            {
                return Courier.LP;
            }

            else
            {
                return Courier.MR;
            }
        }
    }
}






