using Newtonsoft.Json;
using Zowie_recruitement_task.Models;

namespace Zowie_recruitement_task
{
    internal class TicketStatusChecker
    {
        //TODO: we can move api_key to safe place
        private const string URL = "https://customizations.zowie.dev/ecommerce/tickets/";
        private const string API_KEY = "";

        public async Task<TicketsReport> GetTicketReportAsync(List<string> ticketIds)
        {
            var report = new TicketsReport();

            foreach (var ticketId in ticketIds)
            {
                var ticketStatus = await GetTicketStatus(ticketId);
                report.TicketsWithStatus.Add(ticketStatus);
            }

            return report;
        }

        private async Task<TicketIdWithStatus> GetTicketStatus(string ticketId)
        {
            Console.WriteLine($"Fetching status of ticket {ticketId}.");

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-API-KEY", API_KEY);

                try
                {
                    var response = await client.GetAsync($"{URL}{ticketId}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TicketIdWithStatus>(responseData);
                }
                catch (Exception e)
                {
                    return new TicketIdWithStatus()
                    {
                        Id = ticketId,
                        Status = e.Message
                    };
                }
            }
        }
    }
}
