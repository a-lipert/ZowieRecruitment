using Newtonsoft.Json;

namespace Zowie_recruitement_task.Models
{
    internal class TicketIdWithStatus
    {
        [JsonProperty("ticketId")]
        public string Id;

        [JsonProperty("status")]
        public string Status;
    }
}
