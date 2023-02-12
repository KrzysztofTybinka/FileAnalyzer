using FileAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzerTests
{
    public class FileService_Tests
    {
        [Fact]
        public void PrintValues_ReturnsListOfTwoCities_WhenGivenCityKeyAndValues_2()
        {
            // Arrange
            string jsonString = Resources.GetJsonString();
            JsonFileParser parser = new JsonFileParser(jsonString);
            FileService fileService = new FileService(parser);

            // Act
            List<string?> list = fileService.PrintValues("city", "2");

            // Assert
            Assert.Collection(list,
                city => Assert.Equal("Anytown", city),
                city => Assert.Equal("Someplace", city));           
        }
    }
}
