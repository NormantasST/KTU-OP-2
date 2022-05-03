using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class Newspaper : Publication, IComparable<Publication>, IEquatable<Publication>
    {
        public Newspaper(string name, string type, string publisher, DateTime releaseDate, int pageCount, int numberReleased, int number) : base(name, type, publisher, releaseDate, pageCount, numberReleased)
        {
            Number = number;
        }
        public int Number { get; set; }

        /// <summary>
        /// To String Implementation
        /// </summary>
        /// <returns> string </returns>
        public override string ToString()
        {
            return base.ToString() + $"{Number,15} |";
        }

        /// <summary>
        /// CompareTo override
        /// </summary>
        /// <param name="other">  Other Publication to compare to </param>
        /// <returns> Publication </returns>
        public override int CompareTo(Publication other)
        {
            int comparison = ReleaseDate.Year.CompareTo(other.ReleaseDate.Year);
            if (comparison != 0)
            {
                comparison = ReleaseDate.Month.CompareTo(other.ReleaseDate.Month);
            }
            return comparison;
        }

        /// <summary>
        /// iEquatable override
        /// </summary>
        /// <param name="other"> Other Publication to compare to</param>
        /// <returns> Bool </returns>
        public override bool Equals(Publication other)
        {
            return Name == other.Name;
        }

        /// <summary>
        /// IsOld Function. Checks if the publication is old
        /// </summary>
        public override bool IsOld()
        {
            if (DateTime.Now.AddDays(-7).CompareTo(ReleaseDate) > 0)
                return true;
            return false;
        }
    }
}