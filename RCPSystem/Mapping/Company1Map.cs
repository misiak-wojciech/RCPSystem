using CsvHelper.Configuration;
using RCPSystem.Model;

namespace RCPSystem.Mapping
{
    public sealed class Company1Map : ClassMap<WorkDay>
    {
        public Company1Map()
        {
            Map(m => m.EmployeeCode).Index(0);
            Map(m => m.Date).Index(1).TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.ArrivalTime).Index(2);
            Map(m => m.DepartureTime).Index(3);
        }
    }
}
