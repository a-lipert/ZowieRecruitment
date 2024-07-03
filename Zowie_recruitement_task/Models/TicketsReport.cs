namespace Zowie_recruitement_task.Models
{
    internal class TicketsReport
    {
        public TicketsReport()
        {
            TicketsWithStatus = new List<TicketIdWithStatus>();
        }

        public List<TicketIdWithStatus> TicketsWithStatus { get; set; }
        public List<KeyValuePair<string, int>> StatusCount =>
            TicketsWithStatus.GroupBy(x => x.Status)
            .Select(x => new KeyValuePair<string, int>(x.Key, x.Count()))
            .ToList();


    }
}
