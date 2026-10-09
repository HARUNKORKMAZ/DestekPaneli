using DestekPaneli.Domain.Common;
using System.Text;

namespace DestekPaneli.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketMessage> Messages { get; set; }
    }
}
