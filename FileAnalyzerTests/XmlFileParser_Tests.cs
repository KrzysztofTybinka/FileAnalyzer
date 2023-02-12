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
        public void ParseFile_ReturnsListOfStreet_WhenGivenStreetKey()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);

            // Act
            List<string?> cities = parser.ParseFile("street");

            // Assert
            Assert.Collection(cities,
                city => Assert.Equal("123 Main St", city),
                city => Assert.Equal("456 Oak Ave", city),
                city => Assert.Equal("789 Elm St", city),
                city => Assert.Equal("321 Maple St", city));
        }


        [Fact]
        public void ParseFile_ThrowsKeyNotFoundException_WhenGivenSurnameKey()
        {
            // Arrange
            string xmlString = Resources.GetXmlString();
            XmlFileParser parser = new XmlFileParser(xmlString);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => parser.ParseFile("surname"));
        }
    }
}

