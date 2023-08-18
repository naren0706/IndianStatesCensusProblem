using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IndianStatesCensusProblem
{
    public class StateCodeAnalyser
    {
        public static int ReadStateCodeData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new StateCodeException(StateCodeException.ExceptionType.FILE_NOT_EXISTS, "File not exists");
            }
            if (!Path.GetExtension(filePath).Equals(".csv"))
            {
                throw new StateCodeException(StateCodeException.ExceptionType.FILE_INCORRECT, "File extension incorrect");
            }
            if (File.ReadAllLines(filePath)[0].Contains("/") || File.ReadAllLines(filePath)[0].Contains("|"))
            {
                throw new StateCodeException(StateCodeException.ExceptionType.DELIMETER_INCORRECT, "Delimeter Incorrect");
            }
            if (!File.ReadAllLines(filePath)[0].Equals("SrNo,State,Name,TIN,StateCode"))
            {
                throw new StateCodeException(StateCodeException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCodeData>().ToList();
                    Console.WriteLine("Read Data From CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.SrNo + "---" + data.State + "---" + data.Name + "---" + data.TIN + "---" + data.StateCode);
                    }
                    return records.Count() - 1;
                }
            }
        }

    }
}