namespace RPCSystem.Tests
{
    public class Company2ParserTests
    {
        [Fact]
        public void Parse_ValidLines_ReturnsSingleWorkDay()
        {
            // Arrange
            string data = "1143;2025-12-17;08:00;WE\n1143;2025-12-17;16:00;WY";
            var parser = new Company2Parser();
            using var reader = new StringReader(data);

            // Act
            var result = parser.Parse(reader).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("1143", result[0].EmployeeCode);
            Assert.Equal(new DateTime(2025, 12, 17), result[0].Date);
            Assert.Equal(TimeSpan.FromHours(8), result[0].ArrivalTime);
            Assert.Equal(TimeSpan.FromHours(16), result[0].DepartureTime);
        }

        [Fact]
        public void Parse_MissingDeparture_IgnoresWorkDay()
        {
            // Arrange
            string data = "112;2025-12-17;08:00;WE"; // brak WY
            var parser = new Company2Parser();

            using var reader = new StringReader(data);

            // Act
            var result = parser.Parse(reader).ToList();

            // Assert
            Assert.Empty(result); // niepe³ny dzieñ powinien byæ odrzucony
        }


    }
}