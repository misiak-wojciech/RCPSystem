
namespace RPCSystem.Tests
{
    public class Company1ParserTests
    {
        [Fact]
        public void Parse_ValidCsvLine_ReturnWorkDay()
        {
            // Arrange
            string data ="221;2025-12-17;08:00;16:00;480";

            var parser = new Company1Parser();
            using var reader = new StringReader(data);

            // Act
            var result = parser.Parse(reader).ToList();


            // Assert
            Assert.Equal("221", result[0].EmployeeCode);
            Assert.Equal(new DateTime(2025, 12, 17), result[0].Date);
            Assert.Equal(TimeSpan.FromHours(8), result[0].ArrivalTime);
            Assert.Equal(TimeSpan.FromHours(16), result[0].DepartureTime);
        }

      


    }


}
