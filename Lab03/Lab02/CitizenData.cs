using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02
{
    /// <summary>
    /// CitizenData class object to be used by class Citizen
    /// </summary>
    public class CitizenData : IComparable<CitizenData>, IEquatable<CitizenData>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public double TaxSum { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lastName">Last name of the citizen</param>
        /// <param name="firstName">First Name of the citizen</param>
        /// <param name="address">Address of the citizen</param>
        public CitizenData(string lastName, string firstName, string address, double taxSum)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            TaxSum = taxSum;
        }


        /// <summary>
        /// To String override
        /// </summary>
        /// <returns>stringg format of the citizen</returns>
        public override string ToString()
        {
            return $"{LastName,-20} {FirstName,-20}|{Address,-20}|{TaxSum,10:f}|";
        }

        /// <summary>
        /// Compares to other Node of citizen type
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Integer</returns>
        public int CompareTo(CitizenData other)
        {
            int comparison = other.Address.CompareTo(Address);
            if (comparison == 0)
            {
                comparison = other.LastName.CompareTo(LastName);
                if (comparison == 0)
                {
                    comparison = other.FirstName.CompareTo(FirstName);
                }
            }

            return comparison;
        }

        /// <summary>
        /// IEquatable iomplementation
        /// </summary>
        /// <param name="other">Comparison object</param>
        /// <returns>Boolean</returns>
        public bool Equals(CitizenData other)
        {
            if (FirstName == other.FirstName && LastName == other.LastName && Address == other.Address)
                return true;
            return false;
        }

        /// <summary>
        /// IEquatable iomplementation
        /// </summary>
        /// <param name="other">Comparison object</param>
        /// <returns>Boolean</returns>
        public bool Equals(CitizenTaxData other)
        {
            if (FirstName == other.FirstName && LastName == other.LastName && Address == other.Address)
                return true;
            return false;
        }
    }
}