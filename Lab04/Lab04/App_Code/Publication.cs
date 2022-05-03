using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04
{
    public abstract class Publication : IComparable<Publication>, IEquatable<Publication>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PageCount { get; set; }
        public int NumberReleased { get; set; }

        /// <summary>
        /// Custructor
        /// </summary>
        /// <param name="name"> Name of the Publication </param>
        /// <param name="type"> Type of the Publication </param>
        /// <param name="publisher"> Publisher of the publication </param>
        /// <param name="realeseYear"> Year in which the publication was released </param>
        /// <param name="pageCount"> Page Count </param>
        /// <param name="numberReleased"> Number of publications released</param>
        public Publication(string name, string type, string publisher, DateTime releaseDate, int pageCount, int numberReleased)
        {
            Name = name;
            Type = type;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            PageCount = pageCount;
            NumberReleased = numberReleased;
        }

        public override string ToString()
        {
            return $"{Name,-25} |{Type,-15} |{Publisher,-25} |{ReleaseDate,-20} |{PageCount,10} |{NumberReleased,15} |";
        }

        /// <summary>
        /// CompareTo Implementation
        /// </summary>
        /// <param name="other"> Other object to compare to</param>
        /// <returns>integer</returns>
        public virtual int CompareTo(Publication other)
        {
            return ReleaseDate.CompareTo(other.ReleaseDate);
        }

        /// <summary>
        /// Equals Override
        /// </summary>
        /// <param name="other"> Other Publication to compare to</param>
        /// <returns> Boolean </returns>
        public virtual bool Equals(Publication other)
        {
            return Name == other.Name;
        }

        /// <summary>
        /// IsOld Function. Checks if the publication is old
        /// </summary>
        public virtual bool IsOld()
        {
            if(DateTime.Now.AddYears(-1).CompareTo(ReleaseDate) < 0)
                return true;
            return false;
        }

    }
}