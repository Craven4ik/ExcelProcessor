using ExcelProcessor.Services;

Console.Write("Введите путь к файлу: ");
string? filePath = Console.ReadLine();
Console.WriteLine($"Путь к файлу: {filePath}");

if (!File.Exists( filePath ))
{
    Console.WriteLine("Файл не существует");
    return;
}

Console.WriteLine("\nОбщее количество строк и столбцов, включая пустые");

var result = ExcelProcessorService.Process(filePath);

Console.WriteLine($"\nКоличество строк: {result.totalRows}\nКоличество столбцов: {result.totalColumns}" +
    $"\nНомер последней строки: {result.lastRowWithData}\nВремя обработки: {result.processingTime} сек");


Console.WriteLine("\n\nОбщее количество строк и столбцов, исключая пустые");

var result2 = ExcelProcessorService.Process2(filePath);

Console.WriteLine($"\nКоличество строк: {result2.totalRows}\nКоличество столбцов: {result2.totalColumns}" +
    $"\nНомер последней строки: {result2.lastRowWithData}\nВремя обработки: {result2.processingTime} сек");