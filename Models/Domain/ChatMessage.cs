

namespace FarmIt.Models.Domain
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
