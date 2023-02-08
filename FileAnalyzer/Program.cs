namespace FileAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string xmlPath = "C:\\Users\\krzys\\OneDrive\\Pulpit\\employees.xml";
            string jsonPath = "C:\\Users\\krzys\\OneDrive\\Pulpit\\employees.json";

            //var chuj = new XmlFileParser(xmlPath);
            var chujek = new JsonFileParser(jsonPath);
            chujek.ParseFile<string>("employees[*].firstName");
        }
    }
}