using Newtonsoft.Json;
using Zowie_recruitement_task;

namespace MyApp
{

    internal class Program
    {
        private static string FILE_PATH = @".\Tickets.csv";
        private static string REPORT_PATH = @".\TicketsReport.json";
        static async Task Main(string[] args)
        {
            var csvReader = new CsvFileReader();
            var fileData = csvReader.ReadCsvFileSkipHeader(FILE_PATH);

            var statusChecker = new TicketStatusChecker();
            var ticketsReport = await statusChecker.GetTicketReportAsync(fileData);

            File.WriteAllText(REPORT_PATH, JsonConvert.SerializeObject(ticketsReport));

        }


    }
}





