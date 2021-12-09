using System.ComponentModel.DataAnnotations;

namespace AspTicketSample.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }




        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public User User { get; set; }
        public string UserId { get; set; }


        public TicketStatus Status { get; set; }
        public ICollection<TicketMessage> Messages { get; set; }

    }

    public enum TicketStatus
    {
        [Display(Name = "ارسال شده")]
        Send,

        [Display(Name = "پاسخ داده شده")]
        Answered,

        [Display(Name = "در دست برسی")]
        InProcess,

        [Display(Name = "بسته شده")]
        Closed,
    }
}
