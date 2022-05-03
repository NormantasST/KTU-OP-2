using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04
{
    public class Book : Publication, IComparable<Publication>, IEquatable<Publication>
    {
        public Book(string name, string type, string publisher, DateTime releaseDate, int pageCount, int numberReleased, string isbn, string author) : base(name, type, publisher, releaseDate, pageCount, numberReleased)
        {
            ISBN = isbn;
            Author = author;
        }

        public string ISBN { get; set; }
        public string Author { get; set; }

        /// <summary>
        /// To String Implementation
        /// </summary>
        /// <returns> string </returns>
        public override string ToString()
        {
            return base.ToString() + $"{ISBN,-15} |{Author,-20}";
        }

        /// <summary>
        /// CompareTo override
        /// </summary>
        /// <param name="other">  Other Publication to compare to </param>
        /// <returns> Publication </returns>
        public override int CompareTo(Publication other)
        {
            int comparison = ReleaseDate.Year.CompareTo(other.ReleaseDate.Year);
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
            if (DateTime.Now.AddYears(-1).CompareTo(ReleaseDate) > 0)
                return true;
            return false;
        }
    }
}