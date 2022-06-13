using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_ShipmentDiscountCalculationModule
{
   
    public class ReadFile
    {
    

        public static Courier courier;

        public static List<Package> ReadMemberData()
        {
            string[] memberData = System.IO.File.ReadAllLines("Input.txt");

            List<Package> listOfWares = new List<Package>();
           

            foreach (var item in memberData)
            {

                //Splitting the string array to 3 parts: date - package size - courier
                // With the first part - date - finding year - month - day 

                string[] splitData = item.Split(' '); 


                var package = new Package();

                var date = splitData[0];
              
              
                if (DateOnly.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly output))
                {
                   
                    package.Date = output;
                }



                var resultSize = Enum.TryParse<Size>(splitData[1], out var size);



                if (splitData.Length > 2) // Checking if the given format is suitable, do we have data for further actions
                {
                    var resultCourier = Enum.TryParse<Courier>(splitData[2], out var courier);
                    package.Courier = courier;
                }

                if (resultSize)
                {
                    package.Size = size;
                }
                listOfWares.Add(package);

            }

            return listOfWares;
            
        }

        

     
    }

}
