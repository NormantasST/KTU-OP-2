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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Library> ReadData(string fileDirectory)
        {
            List<Library> list = new List<Library>();
            foreach (string filePath in Directory.GetFiles(fileDirectory))
            {
                string[] lines = File.ReadAllLines(filePath);
                Library library = new Library(lines[0], lines[1], lines[2]);
                for (int i = 3; i < lines.Length; i++)
                {
                    string[] elements = lines[i].Split(';');
                    string name = elements[0];
                    string publisherType = elements[1];
                    string type = elements[2];
                    string publisher = elements[3];
                    DateTime releaseDate;
                    int pageCount;
                    int numberReleased;

                    try
                    {
                        releaseDate = DateTime.Parse(elements[4]);
                        pageCount = int.Parse(elements[5]);
                        numberReleased = int.Parse(elements[6]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
                    }
                    try
                    {
                        switch (publisherType)
                        {
                            case "Book":
                                string isbnBook = elements[7];
                                string author = elements[8];
                                Book book = new Book(name, type, publisher, releaseDate, pageCount, numberReleased, isbnBook, author);
                                library.Add(book);
                                break;

                            case "Journal":
                                string isbnJournal = elements[7];
                                int number = int.Parse(elements[8]);
                                Journal journal = new Journal(name, type, publisher, releaseDate, pageCount, numberReleased, isbnJournal, number);
                                library.Add(journal);
                                break;

                            case "Newspaper":
                                int numberPaper = int.Parse(elements[7]);
                                Newspaper paper = new Newspaper(name, type, publisher, releaseDate, pageCount, numberReleased, numberPaper);
                                library.Add(paper);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
                    }
                }
                list.Add(library);
            }
            return list;
        }

        public static void CreateFile(string fileName)
        {
            new StreamWriter(fileName).Close();
        }
        public static void WriteLibrary(List<Library> libraries, string fileName, string header)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, append: true))
                {
                    sw.WriteLine(header);
                    sw.WriteLine();
                    foreach (Library library in libraries)
                    {
                        sw.WriteLine(library.Name);
                        sw.WriteLine(library.Address);
                        sw.WriteLine(library.PhoneNumber);
                        sw.WriteLine(new String('-', 100));
                        sw.WriteLine($"{"Name",-25} |{"Type",-15} |{"Publisher",-25} |{"ReleaseDate",-20} |{"PageCount",-10} |{"NumberReleased",-15} |{"ISBN/Number",-15} |{"Author/Number",-20}");
                        for (int i = 0; i < library.Count; i++)
                        {
                            sw.WriteLine(library.Get(i));
                        }

                        sw.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Writes all publications from List Publicatrion object
        /// </summary>
        /// <param name="publications"> List Publication object</param>
        /// <param name="fileName"> Output file</param>
        /// <param name="header"> Headerd</param>
        public static void WritePublication(List<Publication> publications, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine();
                sw.WriteLine($"{"Name",-25} |{"Type",-15} |{"Publisher",-25} |{"ReleaseDate",-20} |{"PageCount",-10} |{"NumberReleased",-15} |{"ISBN/Number",-15}| {"Author/Number",-20}");
                foreach (Publication publication in publications)
                {
                    sw.WriteLine(publication);
                }
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Writes Older than 2 years List to txt file
        /// </summary>
        /// <param name="libraries"> List Library file </param>
        /// <param name="fileName"> Filename to input file </param>
        /// <param name="header"> Header of the text</param>
        public static void WriteOlderThan(List<Library> libraries, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine();
                foreach (Library library in libraries)
                {
                    sw.WriteLine($"{library.Name} has {library.OlderThanCount(2)} publications older than 2 years");
                    sw.WriteLine();
                }
                sw.WriteLine();
            }
        }

        public static void OutputLargeReleases(List<Publication> publications, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, encoding:System.Text.Encoding.UTF8))
            {
                sw.WriteLine("Name;Release Number");
                foreach (Publication publication in publications)
                {
                    sw.WriteLine($"{publication.Name};{publication.NumberReleased}");
                }
            }
        }
    }
}