﻿using ClosedXML.Excel;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReportRepositories : IReportRepositories
    {
        private readonly ApplicationDbContext _db;

        public ReportRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<MemoryStream> ExportToExcel(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            int row = 4;

            //Load template file
            XLWorkbook workbook = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "tml.xlsx"));
            MemoryStream stream = new();
            var worksheet = workbook.Worksheet(1);

            //Get data from db
            var reports = await _db.Tbl_Mealmoney
            .Where(r => r.SchoolId == schoolId && r.Date >= startDate && r.Date <= endDate).OrderBy(x => x.Date)
            .ToListAsync();

            //Insert data
            foreach (var report in reports)
            {
                worksheet.Cell(row, 1).Value = report.Date.ToString("dd-MM-yyyy");
                worksheet.Cell(row, 2).Value = report.TienAnSang;
                worksheet.Cell(row, 3).Value = report.TienAnTrua;
                worksheet.Cell(row, 4).Value = report.TienAnChieu;
                worksheet.Cell(row, 5).Value = report.PhuPhi;
                row++;
            }

            //Set styles
            worksheet.Range($"A4:E{row - 1}").Style
                .Border.SetTopBorder(XLBorderStyleValues.Thin)
                .Border.SetRightBorder(XLBorderStyleValues.Thin)
                .Border.SetBottomBorder(XLBorderStyleValues.Thin)
                .Border.SetLeftBorder(XLBorderStyleValues.Thin)
                .Font.SetFontName("Times New Roman")
                .Font.SetFontSize(14);

            //Autofit column
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(stream);
            return stream;
        }

        public async Task<MemoryStream> ExportToXml(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            var reports = await _db.Tbl_Mealmoney
                .Where(r => r.SchoolId == schoolId && r.Date >= startDate && r.Date <= endDate).OrderBy(x => x.Date)
                .ToListAsync();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<SchoolRecord>));
            var xmlStream = new MemoryStream();
            var writer = new StreamWriter(xmlStream, System.Text.Encoding.UTF8, 1024, true);
            serializer.Serialize(writer, reports);
            xmlStream.Seek(0, SeekOrigin.Begin);
            return xmlStream;
        }

        public async Task<IEnumerable<SchoolRecord>> ReportMealMoney(Guid schoolId, DateTime startDate, DateTime endDate)
        {
            var reports = await _db.Tbl_Mealmoney
                .Where(r => r.SchoolId == schoolId && r.Date >= startDate && r.Date <= endDate).OrderBy(x => x.Date)
                .ToListAsync();
            return reports;
        }
    }
}
