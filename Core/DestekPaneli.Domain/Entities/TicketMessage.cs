using DestekPaneli.Domain.Common;

namespace DestekPaneli.Domain.Entities
{
    public class TicketMessage : BaseEntity
    {
        public string MessageText { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }
    }
}
