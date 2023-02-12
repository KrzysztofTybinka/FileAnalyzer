using FileAnalyzer;

namespace FileAnalyzerTests
{
    public class JsonFileParser_Tests
    {
        public class JsonFileParserTests
        {
            [Fact]
            public void ParseFile_ReturnsListOfCities_WhenGivenCityKey()
            {
                // Arrange
                string jsonString = Resources.GetJsonString();
                JsonFileParser parser = new JsonFileParser(jsonString);

                // Act
                List<string?> cities = parser.ParseFile("city");

                // Assert
                Assert.Collection(cities,
                    city => Assert.Equal("Anytown", city),
                    city => Assert.Equal("Someplace", city),
                    city => Assert.Equal("Anotherplace", city),
                    city => Assert.Equal("Nowhere", city));
            }
        }
    }
}