using RCPSystem.Model;


namespace RCPSystem.Interface
{
    public interface IRcpParser
    {
        bool CanHandle(string[] firstLineFields);
        IEnumerable<WorkDay> Parse(TextReader reader);
    }
}
