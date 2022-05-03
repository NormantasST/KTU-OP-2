using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        private List<Publication> publications;

        public int Count { get { return publications.Count;  } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"> Name of the library</param>
        /// <param name="adress"> Adress of the library</param>
        /// <param name="phoneNumber"></param>
        public Library(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            publications = new List<Publication>();
        }
        
        /// <summary>
        /// Adds a publication
        /// </summary>
        /// <param name="publication"> Publication Data Type</param>
        public void Add(Publication publication)
        {
            publications.Add(publication);
        }
        
        /// <summary>
        /// Returns Items with selected index. If out of bounds error is thrown, returns null-
        /// </summary>
        /// <param name="index"> index of the item to return</param>
        /// <returns></returns>
        public Publication Get(int index)
        {
            try
            {
                return publications[index];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets The count of publications older than specified num ber
        /// </summary>
        /// <param name="year"> Years to check for older count</param>
        /// <returns> Older Count</returns>
        /// <exception cref="Exception"> Failed to compare the objects, Publication type error</exception>
        public int OlderThanCount(int year)
        {
            int count = 0;
            try
            {
                foreach (Publication publication in publications)
                {
                    if (publication.ReleaseDate.CompareTo(DateTime.Now.AddYears(-year)) < 0)
                    {
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }

            return count;
        }
    }
}