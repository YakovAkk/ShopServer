namespace Server.DTO
{
    public class MessageToMailDTO
    {
        public string email { get; set; }
        public string letter { get; set; }
        public DateTime sendingDateTime { get; set; }
        public MessageToMailDTO()
        {
            sendingDateTime = DateTime.Now;
        }
    }
}
