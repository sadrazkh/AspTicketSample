using Microsoft.AspNetCore.Identity;

namespace AspTicketSample.Data.Entities
{
    public class User : IdentityUser
    {

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
