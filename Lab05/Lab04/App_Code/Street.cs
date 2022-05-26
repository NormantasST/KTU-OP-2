using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public class Street : IEnumerable<Family>
    {
        public string Name { get; set; }
        private List<Family> families;
        public int Count { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"> Name of the street</param>
        public Street(string name)
        {
            Name = name;
            families = new List<Family>();
            Count = 0;
        }

        /// <summary>
        /// Adds an element to List
        /// </summary>
        /// <param name="family"> A family object </param>
        public void Add(Family family)
        {
            families.Add(family);
            Count++;
        }

        /// <summary>
        /// Gets element by Index
        /// </summary>
        /// <param name="index"> int index</param>
        /// <returns> returns Family Object</returns>
        /// <exception cref="Exception"></exception>
        public Family Get(int index)
        {
            try
            {
                return families[index];
            }
            // Index out of bonds
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// String override
        /// </summary>
        /// <returns> object in string form</returns>
        public override string ToString()
        {
            return $"{Name}";
        }

        /// <summary>
        /// IEnumerator implementation
        /// </summary>
        /// <returns> iEnumerator</returns>
        public IEnumerator<Family> GetEnumerator()
        {
            foreach (Family family in families)
                yield return family;

            
        }

        /// <summary>
        /// Depricated
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}