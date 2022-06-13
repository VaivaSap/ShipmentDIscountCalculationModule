using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_ShipmentDiscountCalculationModule
{
    public class Package
    {
        public DateOnly? Date { get; set; }

        public Courier Courier { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }


        public override string ToString()
        {
            
            if(Date == null || Courier == null || Size == null)
            {
                return "Ignored...";

            }

            var changeDisplayOfADiscount = Discount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            if (changeDisplayOfADiscount == "0.00")
            {

                changeDisplayOfADiscount = " - ";
            }


            return Date.ToString() + " " + Size.ToString() + " " + Courier.ToString() + " " + Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + changeDisplayOfADiscount;

         
        }
    }

    

}


