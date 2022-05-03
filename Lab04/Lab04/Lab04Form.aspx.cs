using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab04.App_Code;

namespace Lab04
{
    public partial class Lab04Form : System.Web.UI.Page
    {
        private string inputDirectory = @"App_Data/Data2";
        private string outputFile = @"App_Data/Output.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Starting Data
            List<Library> libraries = InOutUtils.ReadData(Server.MapPath(inputDirectory));
            InOutUtils.CreateFile(Server.MapPath(outputFile));
            InOutUtils.WriteLibrary(libraries, Server.MapPath(outputFile), "Initial Data:");
            AddLibraries(libraries, Table0);

            // Task 1
            InOutUtils.WriteOlderThan(libraries, Server.MapPath(outputFile), "Older Than 2 Years Publications in specific libraries");
            GetOlder(Table1, libraries);

            // Task 2
            List<Publication> withSelectedType = TaskUtils.GetAllWithType(libraries, "Mokslinis");
            InOutUtils.WritePublication(withSelectedType, Server.MapPath(outputFile), "\"Mokslinis\" type publication:");
            FillTable(Table2, withSelectedType);

            // Task 3
            List<Publication> notNewPublications = TaskUtils.GetNotNewPublications(libraries);
            notNewPublications.BubbleSort();
            InOutUtils.WritePublication(notNewPublications, Server.MapPath(outputFile), "Old Publications");
            FillTable(Table3, notNewPublications);

            // Task 4
            List<Publication> largePublications = TaskUtils.GetLargeReleases(libraries);
            InOutUtils.OutputLargeReleases(largePublications, Server.MapPath("App_Data/PopuliarusLeidiniai.csv"));
            FillTable(Table4, largePublications);

        }

        public void AddLibraries(List<Library> libraries, Table table)
        {
            try
            {
                foreach (Library library in libraries)
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(CreateCell(library.Name));
                    row.Cells.Add(CreateCell(library.Address));
                    row.Cells.Add(CreateCell(library.PhoneNumber));
                    table.Rows.Add(row);
                    row = new TableRow();
                    row.Cells.Add(CreateCell("Name"));
                    row.Cells.Add(CreateCell("Type"));
                    row.Cells.Add(CreateCell("Publisher"));
                    row.Cells.Add(CreateCell("ReleaseDate"));
                    row.Cells.Add(CreateCell("PageCount"));
                    row.Cells.Add(CreateCell("NumberReleased"));
                    row.Cells.Add(CreateCell("ISBN/Number"));
                    row.Cells.Add(CreateCell("Author/Number"));
                    table.Rows.Add(row);
                    for (int i = 0; i < library.Count; i++)
                    {
                        Publication publication = library.Get(i);
                        table.Rows.Add(GetRow(publication));
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Gets Older than 2 years publications
        /// </summary>
        /// <param name="table"> Input Table</param>
        /// <param name="libraries">List<Library> libraries</Library></param>
        /// <exception cref="Exception"></exception>
        public void GetOlder(Table table, List<Library> libraries)
        {
            try
            {
                TableRow row = new TableRow();
                foreach (Library library in libraries)
                {
                    TableRow tempRow = new TableRow();
                    tempRow.Cells.Add(CreateCell($"{library.Name} has {library.OlderThanCount(2)} publications older than 2 years"));
                    table.Rows.Add(tempRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Fills Table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="publications"></param>
        /// <exception cref="Exception"></exception>
        public void FillTable(Table table, List<Publication> publications)
        {
            try
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateCell("Name"));
                row.Cells.Add(CreateCell("Type"));
                row.Cells.Add(CreateCell("Publisher"));
                row.Cells.Add(CreateCell("ReleaseDate"));
                row.Cells.Add(CreateCell("PageCount"));
                row.Cells.Add(CreateCell("NumberReleased"));
                row.Cells.Add(CreateCell("ISBN/Number"));
                row.Cells.Add(CreateCell("Author/Number"));
                table.Rows.Add(row);

                foreach (Publication publication in publications)
                {
                    table.Rows.Add(GetRow(publication));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Creates TableRow from Book object
        /// </summary>
        /// <param name="data">Book object</param>
        /// <returns>TableRow object</returns>
        public TableRow GetRow(Publication data)
        {
            TableRow row = new TableRow();
            string[] elements = data.ToString().Split('|');
            foreach (string element in elements)
                row.Cells.Add(CreateCell(element.Trim()));

            return row;
        }

        /// <summary>
        /// Creates TableCell from text to speed up TableCell creation
        /// </summary>
        /// <param name="text">string text to add to the table cell</param>
        /// <returns>TableCell class object</returns>
        protected static TableCell CreateCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Text = text;
            return cell;
        }


    }
}