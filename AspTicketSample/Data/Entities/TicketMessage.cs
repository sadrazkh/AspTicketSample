namespace AspTicketSample.Data.Entities
{
    public class TicketMessage
    {
        public long Id { get; set; }

        public DateTime MessageTime { get; set; }
        public string Message { get; set; }




        public User User { get; set; }
        public string UserId { get; set; }


        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }

    }
}
