using System;
using CsvHelper;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IndianStatesCensusProblem
{
    public class StateCensusAnalyser
    {
        public static int ReadstateCensusData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_EXIST, "File Not Exist");
            }
            if (!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_INCORRECT, "File extension incorrect");
            }
            if (!File.ReadAllLines(filepath)[0].Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, "Header Incorrect");
            }
            if (File.ReadAllLines(filepath)[0].Contains("/") || (File.ReadAllLines(filepath)[0].Contains("|")))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMETER_INCORRECT, "Delimeter Incorrect");
            }
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCensusData>().ToList();
                    Console.WriteLine("Read data from CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.State + "___" + data.Population + "___" + data.AreaInSqKm + "___" + data.DensityPerSqKm);
                    }
                    return records.Count() - 1;
                }
            }
        }
    }
}