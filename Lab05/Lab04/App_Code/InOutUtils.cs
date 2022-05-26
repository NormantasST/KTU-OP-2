using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab04.App_Code
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads Data from file directory
        /// </summary>
        /// <param name="fileDirectory"> file directory</param>
        /// <returns> List of street</returns>
        /// <exception cref="Exception"></exception>
        public static List<Territory> ReadTerritoryData(string filePath)
        {
            List<Territory> list = new List<Territory>();
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(';');
                int adultCount;
                int childCoubt;
                double price;
                try
                {
                    adultCount = int.Parse(elements[0]);
                    childCoubt = int.Parse(elements[1]);
                    price = Double.Parse(elements[2]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
                }

                list.Add(new Territory(adultCount, childCoubt, price));
            }

            return list;
        }

        /// <summary>
        /// Reads Data from file directory
        /// </summary>
        /// <param name="fileDirectory"> file directory</param>
        /// <returns> List of street</returns>
        /// <exception cref="Exception"></exception>
        public static List<Street> ReadStreetData(string fileDirectory)
        {
            List<Street> list = new List<Street>();
            foreach (string filePath in Directory.GetFiles(fileDirectory))
            {
                string[] lines = File.ReadAllLines(filePath);
                Street street = new Street(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] elements = lines[i].Split(';');
                    string owner = elements[0];
                    int adultCount;
                    int childCoubt;
                    double space;
                    try
                    {
                        adultCount = int.Parse(elements[1]);
                        childCoubt = int.Parse(elements[2]);
                        space = Double.Parse(elements[3]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
                    }

                    street.Add(new Family(owner, adultCount, childCoubt, space));
                }
                list.Add(street);
            }
            return list;
        }

        public static void CreateFile(string fileName)
        {
            new StreamWriter(fileName).Close();
        }

        /// <summary>
        /// Adds street object
        /// </summary>
        /// <param name="streets"> street objects that store the street name and families</param>
        /// <param name="fileName"> file to append the data</param>
        /// <param name="header"> header to add a data</param>
        public static void WriteStreets(List<Street> streets, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine();
                foreach (Street street in streets)
                {
                    sw.WriteLine(street.Name);
                    sw.WriteLine(new String('-', 100));
                    sw.WriteLine($"{"Owner",-20}|{"Adults",-10}|{"Children",10}|{"Space",6}|");
                    for (int i = 0; i < street.Count; i++)
                    {
                        sw.WriteLine(street.Get(i));
                    }

                    sw.WriteLine();
                }
            }
        }

        /// <summary>
        /// Adds street object
        /// </summary>
        /// <param name="data"> queried data objects to write</param>
        /// <param name="fileName"> file to append the data</param>
        /// <param name="header"> header to add a data</param>
        public static void WriteQueriedData(List<QueriedData> data, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine();
                sw.WriteLine(new String('-', 100));
                sw.WriteLine($"{"Street",-20}|{"Owner",-20}|{"Children",-15}|{"Space",-10}|");
                foreach (QueriedData q in data)
                {
                    sw.WriteLine(q);
                }

                
            }
        }

        /// <summary>
        /// Writes Territoriy 
        /// </summary>
        /// <param name="territories"> List of object territory</param>
        /// <param name="fileName"> File path to add the information</param>
        /// <param name="header"> header of the append file</param>
        public static void WriteTerritories(List<Territory> territories, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine();
                sw.WriteLine($"{"Adults",-10}|{"Children",-10}|{"Price",-6}|");
                foreach (Territory territory in territories)
                    sw.WriteLine(territory);


                sw.WriteLine();
            }
        }

    }
}