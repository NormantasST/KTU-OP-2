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
        private string inputDirectory = @"App_Data/Data1";
        private string inputFile = @"App_Data/Territory2.txt";
        private string outputFile = @"App_Data/Output.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Starting Data
            List<Street> streets = InOutUtils.ReadStreetData(Server.MapPath(inputDirectory));
            List<Territory> territories = InOutUtils.ReadTerritoryData(Server.MapPath(inputFile));
            InOutUtils.CreateFile(Server.MapPath(outputFile));
            InOutUtils.WriteStreets(streets, Server.MapPath(outputFile), "Initial street data:");
            InOutUtils.WriteTerritories(territories, Server.MapPath(outputFile), "Initial territory data:");
            FillTable(Table0, streets);
            FillTable(Table1, territories);

            // Test Queried Data:
            List<QueriedData> queriedData = TaskUtils.GetQueriableData(streets, territories);
            FillTable(Table4, queriedData);
            InOutUtils.WriteQueriedData(queriedData, Server.MapPath(outputFile), "Queried Data:");

            // Task 2
            List<QueriedData> belowAverage = TaskUtils.GetQueriableData(streets, territories);
            double average = TaskUtils.GetAverage(belowAverage);
            Label1.Text = $"Below Average {average, 0:f} Per Person Price:";
            belowAverage = TaskUtils.GetBelowAverageHouseholds(belowAverage);
            TaskUtils.Sort(belowAverage);
            InOutUtils.WriteQueriedData(belowAverage, Server.MapPath(outputFile), $"Below Average {average,0:f} Per Person Price:");
            FillTable(Table2, belowAverage);

            // Task 1
            Table3.Rows.Clear();
            Session["priceQuery"] = Session["priceQuery"];
            if (Session["priceQuery"] != null)
            {
                Label3.Text = $"Above {Session["priceQuery"], 0:f} Price Households:";
                List<QueriedData> abovePrice = TaskUtils.GetQueriableData(streets, territories);
                abovePrice = TaskUtils.GetWhoPayedAbove(abovePrice, double.Parse(Session["priceQuery"].ToString()));
                TaskUtils.Sort(abovePrice);
                InOutUtils.WriteQueriedData(abovePrice, Server.MapPath(outputFile), $"Above {Session["priceQuery"],0:f} Price Households:");
                FillTable(Table3, abovePrice);
            }
            else
            {
                Label3.Text = "";
            }
        }

        /// <summary>
        /// Fills Table
        /// </summary>
        /// <param name="table"> Table to add the information </param>
        /// <param name="data"> List of queried data to test the information </param>
        /// <exception cref="Exception"></exception>
        public void FillTable(Table table, List<QueriedData> data)
        {
            try
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateCell("Street"));
                row.Cells.Add(CreateCell("Owner"));
                row.Cells.Add(CreateCell("People"));
                row.Cells.Add(CreateCell("Price"));
                table.Rows.Add(row);

                foreach (QueriedData q in data)
                    table.Rows.Add(GetRow(q.ToString()));


            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Fills Table
        /// </summary>
        /// <param name="table"> Table to add the information </param>
        /// <param name="streets"> List of street objects that store families </param>
        /// <exception cref="Exception"></exception>
        public void FillTable(Table table, List<Territory> territories)
        {
            try
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateCell("Adults"));
                row.Cells.Add(CreateCell("Children"));
                row.Cells.Add(CreateCell("Price"));
                table.Rows.Add(row);

                foreach (Territory territory in territories)
                    table.Rows.Add(GetRow(territory.ToString()));
                    
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Fills Table
        /// </summary>
        /// <param name="table"> Table to add the information </param>
        /// <param name="streets"> List of street objects that store families </param>
        /// <exception cref="Exception"></exception>
        public void FillTable(Table table, List<Street> streets)
        {
            try
            {
                foreach (Street street in streets)
                {
                    TableRow streetRow = new TableRow();
                    streetRow.Cells.Add(CreateCell(street.Name));
                    table.Rows.Add(streetRow);

                    TableRow row = new TableRow();
                    row.Cells.Add(CreateCell("Owner"));
                    row.Cells.Add(CreateCell("Adults"));
                    row.Cells.Add(CreateCell("Children"));
                    row.Cells.Add(CreateCell("Space"));
                    table.Rows.Add(row);

                    for (int i = 0; i < street.Count; i++)
                    {
                        table.Rows.Add(GetRow(street.Get(i).ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(" Method {0}, Message {1}, Source {2}", ex.TargetSite, ex.Message, ex.Source));
            }
        }

        /// <summary>
        /// Creates TableRow from string object
        /// </summary>
        /// <param name="test"> text</param>
        /// <returns>Family object</returns>
        public TableRow GetRow(string text)
        {
            TableRow row = new TableRow();
            string[] elements = text.ToString().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
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

        /// <summary>
        /// Price to search submit
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["priceQuery"] = TextBox1.Text;
            Response.Redirect("Lab04Form.aspx");

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["priceQuery"] = null;
            Response.Redirect("Lab04Form.aspx");
        }
    }
}