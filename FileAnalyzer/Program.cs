namespace FileAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string xmlPath = "C:\\Users\\krzys\\OneDrive\\Pulpit\\employees.xml";
            string jsonPath = "C:\\Users\\krzys\\OneDrive\\Pulpit\\employees.json";

            //var chuj = new XmlFileParser(xmlPath);
            //var chujek = new JsonFileParser(jsonPath);
            //chujek.ParseFile<string>("employees[*].firstName");



            Console.WriteLine("File Analyzer is a command-line interface application that provides \n" +
                "methods to analyze data files using different functions given by the user. \n" +
                "User inputs data in format: attribute method value path\n\n" +
                "Where:\n- attribute is file attribute user wants to perform function on.\n" +
                "- method is one of the available methods to perform with given attribute.\n" +
                "- value is method argument.\n-path is a file path.\n\n" +
                "Available methods:\n" +
                "-gt - greater than, prints all attribute values that are greater than given value.\n" +
                "-st - smaller than, prints all attribute values that are smaller than given value.\n" +
                "= - equals, prints all attribute values that are equal to given value.\n\n" +
                "Supported file types - json, xml\n" +
                "─────────────────────────────────────────────────────────────────\n\n");

            try
            {
                while (true)
                {
                    Console.WriteLine("Input data in format: attribute method value path\nTo escape press enter.");
                    string? input = Console.ReadLine();

                    if (String.IsNullOrEmpty(input) )
                    {
                        Environment.Exit(0);
                    }

                    Phrase phrase= new Phrase();
                    phrase.Interpret(input).ForEach(x => Console.WriteLine(x));

                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input format. Try again.");
            }
        }
    }
}