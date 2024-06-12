namespace ExcelProcessor.Entities;

public class ExcelInfo
{
    public int totalRows { get; set; }
    public int totalColumns { get; set; }
    public int lastRowWithData { get; set; }
    public double processingTime { get; set; }
}
