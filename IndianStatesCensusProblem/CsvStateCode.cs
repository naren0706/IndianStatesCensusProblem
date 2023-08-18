using CsvHelper;
using IndianStatesCensusProblem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IndianStateCensusAnaylzer
{
    public class CsvStateCode
    {
        public static int ReadStateCodeData(string filePath)
        {
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