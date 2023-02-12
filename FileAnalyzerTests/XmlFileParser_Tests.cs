using FileAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzerTests
{
    public class XmlFileParser_Tests
    {
        [Fact]
        public void ParseFile_ReturnsListOfCities_WhenGivenCityKey()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);

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
        public void ParseFile_ReturnsListOfStreet_WhenGivenKeyToAnObjct()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);

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
        public void ParseFile_ThrowsKeyNotFoundException_WhenGivenNonExistingKey()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => parser.ParseFile("surname"));
        }
    }
}

