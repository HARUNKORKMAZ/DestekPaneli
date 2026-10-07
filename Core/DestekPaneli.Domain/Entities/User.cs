using DestekPaneli.Domain.Common;

namespace DestekPaneli.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketMessage> Messages { get; set; }
    }
}
