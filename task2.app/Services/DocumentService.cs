using System;
using System.Data;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace task2.app.Services
{
    public class DocumentService
    {
        private string _name { get; set; }
        private ExcelPackage _package;
        private ExcelWorksheet _sheet;

        public DocumentService(string name){
            _name = name;
            // set excel license to non-commercial, it is stated in the repository's page:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            _package = new ExcelPackage(new FileInfo($"{_name}_{DateTime.Now.ToString("ddMMyy-HHmm")}.xlsx"));
            _sheet = _package.Workbook.Worksheets.Add("Report");
        }

        public void LoadFromDataTable(DataTable dt){
            _sheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
            _sheet.Cells[2, 3, dt.Rows.Count + 1, 3].Style.Numberformat.Format = "#,##0.00";
            _sheet.Cells[_sheet.Dimension.Address].AutoFitColumns();
            _package.Save();
        }

        public void Dispose(){
            _package.Dispose();
        }
    }
}