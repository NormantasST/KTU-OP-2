using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02
{
    /// <summary>
    /// TaxData object to be inherited by Tax object
    /// </summary>
    public class TaxData : IComparable<TaxData>, IEquatable<TaxData>
    {
        public string TaxCode { get; set; }
        public string TaxName { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="taxCode"></param>
        /// <param name="taxName"></param>
        /// <param name="price"></param>
        public TaxData(string taxCode, string taxName, double price)
        {
            TaxCode = taxCode;
            TaxName = taxName;
            Price = price;
        }

        /// <summary>
        /// Returns Node in string format
        /// </summary>
        /// <returns>Node in string format</returns>
        public override string ToString()
        {
            return $"{TaxCode,-20}|{TaxName,-20}|{Price,10:f}|";
        }

        /// <summary>
        /// IComparable implementation
        /// </summary>
        /// <param name="other">Comparison object</param>
        /// <returns>Integer</returns>
        public int CompareTo(TaxData other)
        {
            int comparison = Price.CompareTo(other.Price);
            return comparison;
        }

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other"> comparison object </param>
        /// <returns>boolean</returns>
        public bool Equals(TaxData other)
        {
            if (TaxCode == other.TaxCode)
                return true;
            return false;
        }
    }
}