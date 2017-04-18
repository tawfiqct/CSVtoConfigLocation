using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVtoConfigLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            string output = "";
            
            // Read the file and display it line by line.
        
            String locationTag = "<location path=\"{0}\">\n<system.webServer>\n<httpRedirect enabled=\"true\" destination=\"{1}\" httpResponseStatus = \"Permanent\" />\n</system.webServer>\n</location>\n\n";


            using (TextFieldParser parser = new TextFieldParser(@"404.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    output += String.Format(locationTag, fields[0], fields[1]);
                    counter++;
                }
            }
            
            // Set a variable to the My Documents path.
                                    
            File.WriteAllText("output.txt", output);
            

            Console.WriteLine(counter + " Lines");
            Console.ReadLine();
        }
    }
}
