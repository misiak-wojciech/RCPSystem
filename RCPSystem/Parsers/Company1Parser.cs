using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using RCPSystem.Mapping;
using RCPSystem.Interface;
using RCPSystem.Model;

public class Company1Parser : IRcpParser
{
    private readonly CsvConfiguration _config = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = false,
        Delimiter = ";",
    };

    public bool CanHandle(string[] fields) => fields.Length == 5;

    public IEnumerable<WorkDay> Parse(TextReader reader)
    {
        using var csv = new CsvReader(reader, _config);
        csv.Context.RegisterClassMap<Company1Map>();

        foreach (var record in csv.GetRecords<WorkDay>())
        {
            yield return record;
        }
    }
}