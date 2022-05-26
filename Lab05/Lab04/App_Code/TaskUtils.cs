using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public static class TaskUtils
    {
        public static List<QueriedData> GetQueriableData(List<Street> streets, List<Territory> territories)
        {
            // Query 1
            IEnumerable<QueriedData> query =
                from s in streets
                from f in s
                from t in territories
                where f.AdultCount == t.AdultCount && f.ChildCount == t.ChildCount
                select new QueriedData(s.Name, f.Owner, f.AdultCount + f.ChildCount, f.Space * t.Price);

            return query.ToList();
        }

        /// <summary>
        /// Gets Average per person
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double GetAverage(List<QueriedData> data)
        {
            // Query 2
            return data.Sum(q => q.Price) / data.Sum(q => q.PeopleCount);

        }

        /// <summary>
        /// Gets households who payed below average per person
        /// </summary>
        /// <param name="data"> List<QueriedData> object </param>
        /// <returns> A new list Queried Object</returns>
        public static List<QueriedData> GetBelowAverageHouseholds(List<QueriedData> data)
        {
            double average = GetAverage(data);

            // Query 3
            IEnumerable<QueriedData> query = data.Where(q => (q.Price / q.PeopleCount) < average).Select(q => q);

            return query.ToList();
        }

        /// <summary>
        /// Gets households who payed above inputed price
        /// </summary>
        /// <param name="data"> List QueriedData object</param>
        /// <param name="searchPrice"> Price to search by </param>
        /// <returns> List QueriedData object</returns>
        public static List<QueriedData> GetWhoPayedAbove(List<QueriedData> data, double searchPrice)
        {
            // Query 4
            IEnumerable<QueriedData> query = data.Where(q => q.Price > searchPrice).Select(q => q);

            return query.ToList();
        }

        /// <summary>
        /// Sort implementation
        /// </summary>
        /// <param name="data"></param>
        public static List<QueriedData> Sort(List<QueriedData> data)
        {
            // Query 5
            return data.OrderByDescending(q => q.Street).ThenByDescending(q => q.Owner).ToList();
        }
    }
}