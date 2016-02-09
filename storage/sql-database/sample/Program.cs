using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace sql_database_sample
{
    class Program
    {
        static void Main()
        {
            string connectionString = GetConnectionString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var simulator = new DbDataReaderSimulator(1, DatasourceRecord.DataTypeEnum.Double);

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    var totalSw = new Stopwatch();
                    var sw = new Stopwatch();

                    var totalInserted = 0;                    

                    bulkCopy.DestinationTableName = "dbo.Data";
                    bulkCopy.BatchSize = 5000;
                    bulkCopy.NotifyAfter = 10000;
                    bulkCopy.EnableStreaming = false;

                    bulkCopy.SqlRowsCopied += (s, e) => {
                        totalInserted += bulkCopy.NotifyAfter;

                        sw.Stop();
                        Console.WriteLine("({0}) {1} Records Inserted in {2}ms ({3:N0} aggregate rps)", e.RowsCopied, bulkCopy.NotifyAfter, sw.ElapsedMilliseconds, totalInserted / totalSw.Elapsed.TotalSeconds);
                        sw.Restart();
                    };

                    try
                    {
                        sw.Start();
                        totalSw.Start();
                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(simulator);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["TimeSeriesDatabase"].ConnectionString;
        }
    }
}
