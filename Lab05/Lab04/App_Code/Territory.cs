using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class Territory
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="adultCount"> Adult Count in the household </param>
        /// <param name="childCount"> Children Counnt in the household </param>
        /// <param name="price"> Price per square meter </param>
        public Territory(int adultCount, int childCount, double price)
        {
            AdultCount = adultCount;
            ChildCount = childCount;
            Price = price;
        }


        /// <summary>
        /// String override
        /// </summary>
        /// <returns> object in string form</returns>
        public override string ToString()
        {
            return $"{AdultCount,10}|{ChildCount,10}|{Price,6}|";
        }
    }
}