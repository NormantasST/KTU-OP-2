using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab02
{
    public partial class Lab01Form : System.Web.UI.Page
    { 
        private string taxDataInput = @"App_Data/U16a.txt";
        private string citizenDataInput = @"App_Data/U16b.txt";
        private string outputDataPath = @"App_Data/U16result.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkedList<CitizenTaxData> citizenTaxData = null;
            LinkedList<TaxData> taxInfo = null;
            InOutUtils.CreateFile(Server.MapPath(outputDataPath));
            if (File.Exists(Server.MapPath(taxDataInput)))
            {
                taxInfo = InOutUtils.ReadTaxData(Server.MapPath(taxDataInput));
                InOutUtils.WriteTaxData(Server.MapPath(outputDataPath), taxInfo, "Initial Tax Company Data:");
                FillTaxDataTable(taxInfo, InitTaxTable);
            }
            else
            {
                InitTaxLabel.Text = "";
            }

            if (File.Exists(Server.MapPath(citizenDataInput)))
            {
                citizenTaxData = InOutUtils.ReadCitizenTaxData(Server.MapPath(citizenDataInput));
                //citizenTaxData.Sort(); Test
                InOutUtils.WriteCitizenTaxData(Server.MapPath(outputDataPath), citizenTaxData, "Initial Citizen Tax Data:");
                FillCitizenTaxDataTable(citizenTaxData, InitCitizenTable);
            }
            else
            {
                InitCitizenLabel.Text = "";
            }

            if (citizenTaxData != null && taxInfo != null)
            {
                // Reads Initial Data and Outputs the Initial Data To WebForm and to text


                CitizenCalculations(taxInfo, citizenTaxData);
                CheckFiltered(taxInfo, citizenTaxData);
            }
            else
            {
                HeaderLabel.Text = "Plaese Upload remaining data files";
                CalculationsPanel.Visible = false;
            }
        }

        /// <summary>
        /// Does calculations from Tax and CitizenTax object
        /// </summary>
        /// <param name="taxInfo">Tax object</param>
        /// <param name="citizenTaxData">CitizenTax object</param>
        protected void CitizenCalculations(LinkedList<TaxData> taxInfo, LinkedList<CitizenTaxData> citizenTaxData)
        {
            LinkedList<CitizenData> citizensAverage = TaskUtils.CreateCitizenData(taxInfo, citizenTaxData); // For Above Average
            InOutUtils.WriteCitizenData(Server.MapPath(outputDataPath), citizensAverage, "Tax Sum of all citizens:");
            
            citizensAverage.Sort();
            InOutUtils.WriteCitizenData(Server.MapPath(outputDataPath), citizensAverage, "Tax Sum of all citizens SORTED A-Z:");
            FillCitizenTable(citizensAverage, CitizenTaxTable);

            double sum = TaskUtils.GetSum(citizensAverage);
            double average = TaskUtils.GetAverage(citizensAverage);
            InOutUtils.WriteHeader(Server.MapPath(outputDataPath), $"All Citizen TOTAL Tax Sum: {sum:f}");
            InOutUtils.WriteHeader(Server.MapPath(outputDataPath), $"Average Tax Sum: {average:f}");
            AverageTax.Text = $"Average tax per citizen: {average}";
            TotalTaxSum.Text = $"Total tax sum: {sum}";

            citizensAverage = TaskUtils.PayedAboveAverage(citizensAverage);
            InOutUtils.WriteCitizenData(Server.MapPath(outputDataPath), citizensAverage, "Citizens who paid above average:");
            FillCitizenTable(citizensAverage, AboveAverageTable);
        }
        /// <summary>
        /// Updates filtered data
        /// </summary>
        /// <param name="taxInfo">Tax Object</param>
        /// <param name="citizenTaxData">CitizenTax object</param>
        protected void CheckFiltered(LinkedList<TaxData> taxInfo, LinkedList<CitizenTaxData> citizenTaxData)
        {
            if (Session["TaxCode"] != null && Session["Month"] != null)
            {
                LinkedList<CitizenData> citizensFiltered = TaskUtils.CreateCitizenData(taxInfo, citizenTaxData); // For Filter
                citizensFiltered = TaskUtils.GetWhoPayedTaxes(citizensFiltered, Session["TaxCode"].ToString(), Session["Month"].ToString(), citizenTaxData);
                citizensFiltered.Sort();
                InOutUtils.WriteCitizenData(Server.MapPath(outputDataPath), citizensFiltered, $"Citizens who paid TaxCode: \"{Session["TaxCode"]}\" on Month: \"{Session["Month"]}\"");
                FillCitizenTable(citizensFiltered, FilterTable);
            }
            else
            {
                FilterData.Text = "No Filter provided";
                FilterTable.Visible = false;
            }

            Session["TaxCode"] = null;
            Session["Month"] = null;
        }

        /// <summary>
        /// Fills Table from CitizenTax object
        /// </summary>
        /// <param name="citizenTaxes">CitizenTaxData LinkedList</param>
        /// <param name="table">Table UI object</param>
        protected void FillCitizenTaxDataTable(LinkedList<CitizenTaxData> citizenTaxes, Table table)
        {
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(CreateCell("Last Name"));
            headerRow.Cells.Add(CreateCell("First Name"));
            headerRow.Cells.Add(CreateCell("Address"));
            headerRow.Cells.Add(CreateCell("Month"));
            headerRow.Cells.Add(CreateCell("Tax Code"));
            headerRow.Cells.Add(CreateCell("Amount"));
            table.Rows.Add(headerRow);
            foreach (CitizenTaxData data in citizenTaxes)
            {
                table.Rows.Add(GetRow(data));
            }
        }

        /// <summary>
        /// Fills Table from Tax object
        /// </summary>
        /// <param name="taxes">LinkedList TaxData object</param>
        /// <param name="table">UI Table object</param>
        protected void FillTaxDataTable(LinkedList<TaxData> taxes, Table table)
        {
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(CreateCell("Tax Code"));
            headerRow.Cells.Add(CreateCell("Tax Company Name:"));
            headerRow.Cells.Add(CreateCell("Price:"));;
            table.Rows.Add(headerRow);
            foreach (TaxData data in taxes)
            {          
                table.Rows.Add(GetRow(data));
            }
        }

        /// <summary>
        /// Fills citizen table
        /// </summary>
        /// <param name="citizens">Citizen object</param>
        /// <param name="table">UI.Table object</param>
        protected void FillCitizenTable(LinkedList<CitizenData> citizens, Table table)
        {
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(CreateCell("Last Name"));
            headerRow.Cells.Add(CreateCell("First Name"));
            headerRow.Cells.Add(CreateCell("Address"));
            headerRow.Cells.Add(CreateCell("Tax Sum"));
            table.Rows.Add(headerRow);
            foreach (CitizenData data in citizens)
            {
                table.Rows.Add(GetRow(data));
            }
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            string taxCode = TaxCodeTextBox.Text;
            string month = TaxMonthTextBox.Text;
            if (month != "" && taxCode != null)
            {
                Session["TaxCode"] = TaxCodeTextBox.Text;
                Session["Month"] = TaxMonthTextBox.Text;
            }
            Response.Redirect("Lab01Form.aspx");
        }

        protected void DataButton_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile && FileUpload1.FileName.EndsWith(".txt"))
            {
                FileUpload1.SaveAs(Server.MapPath(taxDataInput));
            }
            if (FileUpload2.HasFile && FileUpload2.FileName.EndsWith(".txt"))
            {
                FileUpload2.SaveAs(Server.MapPath(citizenDataInput));
            }
            Response.Redirect("Lab01Form.aspx");
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
        /// Creates TableRow from TaxData object
        /// </summary>
        /// <param name="data">TaxData object</param>
        /// <returns>TableRow object</returns>
        public TableRow GetRow(TaxData data)
        {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCell(data.TaxCode));
            row.Cells.Add(CreateCell(data.TaxName));
            row.Cells.Add(CreateCell(data.Price.ToString()));
            return row;
        }

        /// <summary>
        /// Creates a row from CitizenTaxData
        /// </summary>
        /// <param name="data">CitizenTaxData class object</param>
        /// <returns>TableRow object</returns>
        public TableRow GetRow(CitizenTaxData data)
        {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCell(data.LastName));
            row.Cells.Add(CreateCell(data.FirstName));
            row.Cells.Add(CreateCell(data.Address));
            row.Cells.Add(CreateCell(data.Month));
            row.Cells.Add(CreateCell(data.TaxCode));
            row.Cells.Add(CreateCell(data.TaxAmount.ToString()));
            return row;
        }



        /// <summary>
        /// Returns cictizen in TableRow format for the specified citizen
        /// </summary>
        /// <param name="data">data of the citizen</param>
        /// <returns>TableRow format of the specified citizen</returns>
        public TableRow GetRow(CitizenData data)
        {
            TableRow row = new TableRow();
            row.Cells.Add(CreateCell(data.LastName));
            row.Cells.Add(CreateCell(data.FirstName));
            row.Cells.Add(CreateCell(data.Address));
            row.Cells.Add(CreateCell(data.TaxSum.ToString()));
            return row;
        }
    }
}