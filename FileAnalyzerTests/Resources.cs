using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzerTests
{
    /// <summary>
    /// Provides resources for testing methods.
    /// </summary>
    public static class Resources
    {
        /// <summary>
        /// Holds string repsentation of json file.
        /// </summary>
        /// <returns>String repsentation of json file.</returns>
        public static string GetJsonString()
        {
            return "{\r\n  \"people\": [\r\n    {\r\n      \"name\": \"John\",\r\n      " +
                "\"age\": 30,\r\n      \"address\": {\r\n        \"street\": \"123 Main St\",\r\n       " +
                " \"city\": \"Anytown\"\r\n      }\r\n    },\r\n    {\r\n      \"name\": \"Jane\",\r\n      " +
                "\"age\": 25,\r\n      \"address\": {\r\n        \"street\": \"456 Oak Ave\",\r\n        " +
                "\"city\": \"Someplace\"\r\n      }\r\n    },\r\n    {\r\n      \"name\": \"Bob\",\r\n      " +
                "\"age\": 40,\r\n      \"address\": {\r\n        \"street\": \"789 Elm St\",\r\n        " +
                "\"city\": \"Anotherplace\"\r\n      }\r\n    },\r\n    {\r\n      \"name\": \"Sue\",\r\n      " +
                "\"age\": 35,\r\n      \"address\": {\r\n        \"street\": \"321 Maple St\",\r\n        " +
                "\"city\": \"Nowhere\"\r\n      }\r\n    }\r\n  ]\r\n}\r\n";
        }

        /// <summary>
        /// Holds string repsentation of xml file.
        /// </summary>
        /// <returns>String repsentation of xml file.</returns>
        public static string GetXmlString()
        {
            return "<people>\r\n  <person>\r\n    <name>John</name>\r\n    <age>30</age>\r\n    " +
                "<address>\r\n      <street>123 Main St</street>\r\n      <city>Anytown</city>\r\n    " +
                "</address>\r\n  </person>\r\n  <person>\r\n    <name>Jane</name>\r\n    <age>25</age>\r\n    " +
                "<address>\r\n      <street>456 Oak Ave</street>\r\n      <city>Someplace</city>\r\n    " +
                "</address>\r\n  </person>\r\n  <person>\r\n    <name>Bob</name>\r\n    <age>40</age>\r\n    " +
                "<address>\r\n      <street>789 Elm St</street>\r\n      <city>Anotherplace</city>\r\n   " +
                " </address>\r\n  </person>\r\n  <person>\r\n    <name>Sue</name>\r\n    <age>35</age>\r\n    " +
                "<address>\r\n      <street>321 Maple St</street>\r\n      <city>Nowhere</city>\r\n    " +
                "</address>\r\n  </person>\r\n</people>\r\n";
        }
    }
}
