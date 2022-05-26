using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class QueriedData
    { 
        public string Street { get; set; }
        public string Owner { get; set; }
        public int PeopleCount { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street"> Street where the person lives</param>
        /// <param name="owner"> Lastname of the owner </param>
        /// <param name="peopleCount"> How many people live in the household</param>
        /// <param name="price"> Price per cleaning for the household </param>
        public QueriedData(string street, string owner, int peopleCount, double price)
        {
            Street = street;
            Owner = owner;
            PeopleCount = peopleCount;
            Price = price;
        }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns> string </returns>
        public override string ToString()
        {
            return $"{Street, -20}|{Owner, -20}|{PeopleCount,15}|{Price,10:f}";
        }
    }
}