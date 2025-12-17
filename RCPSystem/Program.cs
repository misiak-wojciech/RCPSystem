using RCPSystem;
using RCPSystem.Interface;

class Program
{
    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Error: You must provide the path to the CSV folder as an argument.");
            
            return;
        }

        string dataPath = args[0];

        if (!Directory.Exists(dataPath))
        {
            Console.WriteLine($"Error: The folder '{dataPath}' does not exist.");
            return;
        }

        Console.WriteLine($"Working directory identified: {dataPath}");

        var parsers = new List<IRcpParser> { new Company1Parser(), new Company2Parser() };
        var processor = new RcpProcessor(parsers);
        var results = processor.ProcessDirectory(dataPath);

        Console.WriteLine($"{"Code"} | {"Date"} | {"Arrival"} | {"Departure"}\n");
       

        foreach (var item in results)
        {
            Console.WriteLine($"{item.EmployeeCode,-4} | {item.Date:yyyy-MM-dd} | {item.ArrivalTime} | {item.DepartureTime}");
        }
    }
}