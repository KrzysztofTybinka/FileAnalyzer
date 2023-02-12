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

        [Fact]
        public void PrintValues_ReturnsListWithLength3_WhenGivenCityKeyAndValues_3()
        {
            // Arrange
            string jsonString = Resources.GetJsonString();
            JsonFileParser parser = new JsonFileParser(jsonString);
            FileService fileService = new FileService(parser);

            // Act
            List<string?> list = fileService.PrintValues("city", "3");

            // Assert
            Assert.Equal(3, list.Count);
        }


        [Fact]
        public void PrintValues_ReturnsListWithLength4_WhenGivenStreetKeyAndValues_0()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);
            FileService fileService = new FileService(parser);

            // Act
            List<string?> list = fileService.PrintValues("street", "0");

            // Assert
            Assert.Equal(4, list.Count);
        }


        [Fact]
        public void PrintValues_ReturnsEmptyList_WhenGivenNonExistingKey()
        {
            // Arrange
            string jsonString = Resources.GetJsonString();
            JsonFileParser parser = new JsonFileParser(jsonString);
            FileService fileService = new FileService(parser);

            // Assert
            Assert.Throws<KeyNotFoundException>(() => parser.ParseFile("nonexisting"));
        }
    }
}
