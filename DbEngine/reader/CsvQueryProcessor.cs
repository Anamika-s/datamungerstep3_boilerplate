using System;
using System.IO;
using System.Text.RegularExpressions;
using DbEngine.query;

namespace DbEngine.reader
{
    public class CsvQueryProcessor: QueryProcessingEngine
    {
        private readonly string _fileName;
        private StreamReader _reader;

        // Parameterized constructor to initialize filename
        public CsvQueryProcessor(string fileName)
        {
            //* ADDED CODE  //
            this._fileName = fileName;
            //* ADDED CODE  //

        }

        /*
	    Implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    Note: Return type of the method will be Header
	    */
        public override Header GetHeader()
        {
            // read the first line
            // populate the header object with the String array containing the header names

            FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str;
            while((str = sr.ReadLine()) !=null)
            {
                System.Console.WriteLine("Display Headers");
                System.Console.WriteLine(str);
                break;
            }

            string[] head = str.Split(",");
            Header header = new Header();
            header.setHeader(head);
            return header;

            
        }

        /*
	    Implementation of getColumnType() method. To find out the data types, we will
	    read the first line from the file and extract the field values from it. If a
	    specific field value can be converted to Integer, the data type of that field
	    will contain "System.Int32", otherwise if it can be converted to Double,
	    then the data type of that field will contain "System.Double", otherwise,
	    the field is to be treated as String. 
	     Note: Return Type of the method will be DataTypeDefinitions
	 */
        public override DataTypeDefinitions GetColumnType()
        {
            DataTypeDefinitions dataTypeDefinitions = new DataTypeDefinitions();


            // read the first line
            // populate the header object with the String array containing the header names
            String[] dataTypeArray = new string[18];
            FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            while ((str = sr.ReadLine()) != null)
            {
                break;
            }

            int i = 0;
            string integerPattern = @"^[0-9]+";
            string stringPattern = @"^[a-z- A-Z]+";
            string otherPattern = @"[0-9]{4}[-][0-9]{2}[-][0-9]{2}";           
            string[] head = str.Split(","); 
            foreach(string temp in  head)
            {
                Match match1 = Regex.Match(temp, integerPattern);
                Match match2 = Regex.Match(temp, stringPattern);
                Match match3 = Regex.Match(temp, otherPattern);
                
                if (match3.Success)
                    dataTypeArray[i] = "System.String";
                else if (match1.Success)
                    dataTypeArray[i] = "System.Int32";
                else if (match2.Success)
                    dataTypeArray[i] = "System.String";
                
                if (temp.Length==0)
                    dataTypeArray[i] = "System.String";
                i++;
            }
                
            dataTypeDefinitions.setColumns(dataTypeArray);
            return dataTypeDefinitions;
        }

         //getDataRow() method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}