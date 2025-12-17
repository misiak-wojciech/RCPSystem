using RCPSystem.Interface;
using RCPSystem.Model;
using System.Globalization;

public class Company2Parser : IRcpParser
{
    public bool CanHandle(string[] fields) => fields.Length == 4;

    public IEnumerable<WorkDay> Parse(TextReader reader)
    {
        string? line;
        var events = new List<(string Code, DateTime Date, TimeSpan Time, string Type)>();

        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';');
            if (parts.Length < 4) continue;

            if (DateTime.TryParse(parts[1].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) &&
                TimeSpan.TryParse(parts[2].Trim(), out var time))
            {
                events.Add((parts[0].Trim(), date, time, parts[3].Trim()));
            }
        }

        foreach (var group in events.GroupBy(e => (e.Code, e.Date)))
        {
            TimeSpan? arrival = null;
            TimeSpan? departure = null;

            foreach (var ev in group)
            {
                if (ev.Type.Equals("WE", StringComparison.OrdinalIgnoreCase))
                    arrival = ev.Time;
                else if (ev.Type.Equals("WY", StringComparison.OrdinalIgnoreCase))
                    departure = ev.Time;
            }

            if (arrival.HasValue && departure.HasValue)
            {
                yield return new WorkDay
                {
                    EmployeeCode = group.Key.Code,
                    Date = group.Key.Date,
                    ArrivalTime = arrival.Value,
                    DepartureTime = departure.Value
                };
            }
        }
    }
}
