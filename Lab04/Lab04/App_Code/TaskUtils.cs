using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public static class TaskUtils
    {
        /// <summary>
        /// Gets all Publications with specified Typer
        /// </summary>
        /// <param name="libraries"> List Library class object</param>
        /// <param name="type"> string, type of the object</param>
        /// <returns></returns>
        public static List<Publication> GetAllWithType(List<Library> libraries, string type)
        {
            List<Publication> list = new List<Publication>();

            try
            {
                foreach (Library library in libraries)
                {
                    for (int i = 0; i < library.Count; i++)
                    {
                        Publication publication = library.Get(i);
                        if(publication.Type == type)
                            list.Add(publication);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }

            return list;
        }

        public static void BubbleSort( this List<Publication> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if(list[j].CompareTo(list[j]) < 0)
                    {
                        Publication temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Gets Not New Publications
        /// </summary>
        /// <param name="libraries"> All Library datas</param>
        /// <returns> List Publications of not new publicaitopns</returns>
        /// <exception cref="Exception"></exception>
        public static List<Publication> GetNotNewPublications(List<Library> libraries)
        {
            List<Publication> list = new List<Publication>();

            try
            {
                foreach (Library library in libraries)
                {
                    for (int i = 0; i < library.Count; i++)
                    {
                        Publication publication = library.Get(i);
                        if(publication.IsOld())
                        {
                            list.Add(publication);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }

            return list;
        }

        /// <summary>
        /// Gets LargeReleases
        /// </summary>
        /// <param name="libraries"> All Libraries to check data for</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Publication> GetLargeReleases(List<Library> libraries)
        {
            List<Publication> list = new List<Publication>();
            try
            {
                foreach (Library library in libraries)
                {
                    for (int i = 0; i < library.Count; i++)
                    {
                        Publication pub = library.Get(i);
                        if(pub.NumberReleased >= 10000)
                            list.Add(pub);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }

            return list;
        }
    }
}