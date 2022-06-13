using System;
using System.Collections.Generic;



namespace VS_ShipmentDiscountCalculationModule
{

    class Program
    {

        public static void Main(string[] args)
        {
            var consumersList = ReadFile.ReadMemberData();

            int? previousMonth = null;
            double monthlyDiscount = 0;
            int timesOfSendingL = 0;
         

            foreach (var item in consumersList)
            {

                if (item.Date != null)
                {
                    if (previousMonth != item.Date.Value.Month) // Cheking if the month in a list changes
                    {
                   

                        monthlyDiscount = 0;
                        timesOfSendingL = 0;

                    }


                    previousMonth = item.Date.Value.Month;


                }

                if (item.Size == Size.S)
                {


                    var courierForS = Rules.GetCourier(item.Size);

                    var priceForS = PricesOfSending.GetPrice(courierForS, Size.S);

                    item.Price = priceForS;

                    if (item.Courier == Courier.MR)
                    {
                        // If the more expensive courier is used, a discount will be a difference between prices
                        var discountForSMR = PricesOfSending.MRPrices[Size.S] - PricesOfSending.LPPrices[Size.S];


                     

                        if (monthlyDiscount + discountForSMR <= 10.00)
                        {
                            monthlyDiscount += discountForSMR;

                        }

                        else
                        {
                            double partialDiscount = 10.00 - monthlyDiscount;
                            discountForSMR = partialDiscount;

                            if (priceForS > 0)
                            {
                                item.Price = PricesOfSending.MRPrices[Size.S] - partialDiscount;
                                monthlyDiscount += partialDiscount;
                            }
                                
                        }

                        item.Discount = discountForSMR;

                      

                    }
                }



                if (item.Size == Size.M)
                {
                    if (item.Courier == Courier.LP)
                    {
                        var priceForM = PricesOfSending.LPPrices[Size.M];

                        item.Price = priceForM;

                    }
                    else
                    {
                        var priceForM = PricesOfSending.MRPrices[Size.M];


                        item.Price = priceForM;
                    }



                }
                if (item.Size == Size.L)
                {
                    var priceForL = PricesOfSending.GetPrice(item.Courier, Size.L);

                    item.Price = priceForL;

                    if (item.Courier == Courier.LP)
                    {

                        timesOfSendingL++; // Finding out if an L package was sent at least 3 times 


                    }

                    if (timesOfSendingL == 3) // If an L poackage was sent at least 3 times, a discount is added 
                    {
                        var discountForLLP = PricesOfSending.LPPrices[Size.L];

                        if (monthlyDiscount + discountForLLP <= 10.00)
                        {
                            monthlyDiscount += discountForLLP;


                        }


                        else
                        {
                            double partialDiscount = 10.00 - monthlyDiscount;
                            discountForLLP = partialDiscount;

                            monthlyDiscount += partialDiscount;
                        }

                        item.Discount = discountForLLP;
                        item.Price = priceForL - discountForLLP;
                   
                    }


                }



                Console.WriteLine(item);
                //Console.WriteLine(monthlyDiscount);
            }


            try
            {
               
                StreamWriter sw = new StreamWriter("VS_VinternChallenge_Output.txt");


                foreach (var package in consumersList)
                {
                    sw.WriteLine(package);
                }
         
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Output was created");
            }
        }




    }
}











