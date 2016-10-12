using ServiceStack;
using System.IO;

namespace CsvDataGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var records = RandomDatasourceRecordGenerator.GenerateDummyData(1000000);
            File.WriteAllText("out.csv", records.ToCsv());
        }
    }
}
