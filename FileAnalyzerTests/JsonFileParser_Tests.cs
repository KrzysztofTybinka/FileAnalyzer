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


            [Fact]
            public void ParseFile_ReturnsListOfStreet_WhenGivenStreetKey()
            {
                // Arrange
                string jsonString = Resources.GetJsonString();
                JsonFileParser parser = new JsonFileParser(jsonString);

                // Act
                List<string?> streets = parser.ParseFile("street");

                // Assert
                Assert.Collection(streets,
                    street => Assert.Equal("123 Main St", street),
                    street => Assert.Equal("456 Oak Ave", street),
                    street => Assert.Equal("789 Elm St", street),
                    street => Assert.Equal("321 Maple St", street));
            }


            [Fact]
            public void ParseFile_ThrowsInvalidCastException_WhenGivenKeyToAnObject()
            {
                // Arrange
                string jsonString = Resources.GetJsonString();
                JsonFileParser parser = new JsonFileParser(jsonString);

                // Act & Assert
                Assert.Throws<InvalidCastException>(() => parser.ParseFile("address"));
            }


            [Fact]
            public void ParseFile_ThrowsKeyNotFoundException_WhenGivenNonExistingKey()
            {
                // Arrange
                string jsonString = Resources.GetJsonString();
                JsonFileParser parser = new JsonFileParser(jsonString);

                // Act & Assert
                Assert.Throws<KeyNotFoundException>(() => parser.ParseFile("surname"));
            }
        }
    }
}