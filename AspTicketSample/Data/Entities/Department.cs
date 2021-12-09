using System.ComponentModel.DataAnnotations;

namespace AspTicketSample.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }


        [MaxLength(150)]
        public string Title { get; set; }


        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
