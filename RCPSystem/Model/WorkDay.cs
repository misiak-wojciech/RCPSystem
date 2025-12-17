
namespace RCPSystem.Model
{
    public record WorkDay
    {
        public string EmployeeCode { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public TimeSpan ArrivalTime { get; init; }
        public TimeSpan DepartureTime { get; init; }
    }
}
