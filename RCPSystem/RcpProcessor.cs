
using RCPSystem.Interface;
using RCPSystem.Model;

namespace RCPSystem
{
    public class RcpProcessor
    {
        private readonly List<IRcpParser> _parsers;

        public RcpProcessor(List<IRcpParser> parsers) => _parsers = parsers;

        public List<WorkDay> ProcessDirectory(string path)
        {
            var allResults = new List<WorkDay>();
            var files = Directory.GetFiles(path, "*.csv");

            foreach (var file in files)
            {
                try
                {
                    string[] firstLineFields = GetFirstLineFields(file);
                    var parser = _parsers.FirstOrDefault(p => p.CanHandle(firstLineFields));

                    if (parser == null)
                    {
                        Console.WriteLine($"Skipping file {Path.GetFileName(file)}: Format not recognized.");
                        continue;
                    }

                    using var reader = new StreamReader(file);
                    allResults.AddRange(parser.Parse(reader));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {Path.GetFileName(file)}: {ex.Message}");
                }
            }

            return allResults;
        }

        private string[] GetFirstLineFields(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var firstLine = reader.ReadLine();
            return firstLine?.Split(';') ?? Array.Empty<string>();
        }
    }
}
