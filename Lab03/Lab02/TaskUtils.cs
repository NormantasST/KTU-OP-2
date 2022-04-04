using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab02
{
    /// <summary>
    /// TaskUtils static class for helper functions
    /// </summary>
    public static class TaskUtils
    {

        /// <summary>
        /// Creates Citizen class object using Tax object
        /// </summary>
        /// <param name="TaxList">Tax class object</param>
        /// <param name="citizenTaxList">CitizenTax object</param> 
        /// <returns>Citizen class object</returns>
        public static LinkedList<CitizenData> CreateCitizenData(LinkedList<TaxData> taxList, LinkedList<CitizenTaxData> citizenTaxList)
        {
            LinkedList<CitizenData> citizens = new LinkedList<CitizenData>();
            // Goes through every tax data record
            foreach (CitizenTaxData citizenTaxData in citizenTaxList)
            {
                // Finds the the tax code and returns price
                foreach(TaxData taxData in taxList)
                {
                    if(citizenTaxData.TaxCode == taxData.TaxCode)
                    {
                        CitizenData temp = null;
                        // Finds the citizen if already exists
                        foreach (CitizenData citizen in citizens)
                        {
                            // Finds the citizen if it already exists
                            if(citizen.Equals(citizenTaxData))
                            {
                                temp = citizen;
                                break;
                            }
                        }

                        // Creates a new citizen or appends the data
                        if (temp != null)
                        {
                            temp.TaxSum += (double)taxData.Price * citizenTaxData.TaxAmount;
                        }
                        else
                        {
                            temp = new CitizenData(citizenTaxData.LastName, citizenTaxData.FirstName, citizenTaxData.Address, (double)taxData.Price * citizenTaxData.TaxAmount);
                            citizens.Add(temp);
                        }

                    }
                }
            }

            return citizens;
        }

        /// <summary>
        /// Returns a list for people who payed above average
        /// </summary>
        /// <param name="citizens">CitizenData Linked List</param>
        /// <returns>Citizen Data Linked List</returns>
        public static LinkedList<CitizenData> PayedAboveAverage(LinkedList<CitizenData> citizens)
        {
            double average = GetAverage(citizens);
            LinkedList<CitizenData> output = new LinkedList<CitizenData>();

            foreach (CitizenData citizen in citizens)
            {
                if (citizen.TaxSum >= average)
                {
                    output.Add(citizen);
                }
            }

            return output;
        }

         /// <summary>
         /// Creates a new list who payed taxes specified tax, month
         /// 
         /// </summary>
         /// <param name="citizens">CitizenData Linked List</param>
         /// <param name="taxCode">Tax Code to filter by</param>
         /// <param name="month">Month to filter by</param>
         /// <param name="citizenTaxData">CitizenTaxData Linked List</param>
         /// <returns></returns>
        public static LinkedList<CitizenData> GetWhoPayedTaxes(LinkedList<CitizenData> citizens, string taxCode, string month, LinkedList<CitizenTaxData> citizenTaxData)
        {
            LinkedList<CitizenData> output = new LinkedList<CitizenData>();
            foreach (CitizenData citizen in citizens)
            {
                foreach (CitizenTaxData citizenTax in citizenTaxData)
                {
                    if(citizenTax.TaxCode == taxCode && citizenTax.Month == month && citizen.Equals(citizenTax))
                    {
                        output.Add(citizen);
                        break;
                    }
                }
            }
            return output;
        }

        /// <summary>
        /// Returns Sum
        /// </summary>
        /// <param name="list">CitizenData LinkedList</param>
        /// <returns>Double</returns>
        public static double GetSum(LinkedList<CitizenData> list)
        {
            double sum = 0;
            foreach (CitizenData citizen in list)
                sum += citizen.TaxSum;

            return sum;
        }

        /// <summary>
        /// Gets Average
        /// </summary>
        /// <param name="list">CitizenData Linked List</param>
        /// <returns>Double</returns>
        public static double GetAverage(LinkedList<CitizenData> list)
        {
            double sum = 0;
            int i = 0;
            foreach (CitizenData citizen in list)
            {
                sum += citizen.TaxSum;
                i++;
            }

            return (double)(i > 0 ? sum / i : 0);
        }


    }
}