using ExcelProcessor.Entities;
using OfficeOpenXml;
using System.Diagnostics;

namespace ExcelProcessor.Services;

public static class ExcelProcessorService
{
    public static ExcelInfo Process(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        ExcelInfo processingResult = new ExcelInfo();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
        {
            var sheet = package.Workbook.Worksheets[0];

            processingResult.totalRows = sheet.Dimension.Rows;
            processingResult.totalColumns = sheet.Dimension.Columns;
            int lastRowWithData = sheet.Dimension.Rows;

            for (int row = sheet.Dimension.Rows; row >= 1; row--)
            {
                if (!string.IsNullOrEmpty(sheet.Cells[row, 1].Text))
                {
                    lastRowWithData = row;
                    break;
                }
            }

            processingResult.lastRowWithData = lastRowWithData;
        }

        stopwatch.Stop();

        processingResult.processingTime = stopwatch.Elapsed.TotalSeconds;

        return processingResult;
    }

    public static ExcelInfo Process2(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        ExcelInfo processingResult = new ExcelInfo();

        int totalRows = 0;
        int totalColumns = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
        {
            var sheet = package.Workbook.Worksheets[0];

            int lastRowWithData = sheet.Dimension.Rows;

            for (int row = 1; row <= sheet.Dimension.Rows; row++)
                if (!string.IsNullOrEmpty(sheet.Cells[row, 1].Text))
                    totalRows++;

            for (int col = 1; col <= sheet.Dimension.Columns; col++)
                if (!string.IsNullOrEmpty(sheet.Cells[1, col].Text))
                    totalColumns++;

            processingResult.lastRowWithData = lastRowWithData;
        }

        stopwatch.Stop();

        processingResult.totalRows = totalRows;
        processingResult.totalColumns = totalColumns;
        processingResult.processingTime = stopwatch.Elapsed.TotalSeconds;

        return processingResult;
    }
}
