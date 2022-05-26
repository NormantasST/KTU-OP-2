using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class Family
    {
        public string Owner { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }

        public double Space { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner">Last name of the owner</param>
        /// <param name="adultCount"> Adults in the household</param>
        /// <param name="childCount"> Children in the household</param>
        /// <param name="space"> space in square meters in the household house</param>
        public Family(string owner, int adultCount, int childCount, double space)
        {
            Owner = owner;
            AdultCount = adultCount;
            ChildCount = childCount;
            Space = space;
        }


        /// <summary>
        /// String override
        /// </summary>
        /// <returns> object in string form</returns>
        public override string ToString()
        {
            return $"{Owner,-20}|{AdultCount,10}|{ChildCount, 10}|{Space, 6}|";
        }
    }
}