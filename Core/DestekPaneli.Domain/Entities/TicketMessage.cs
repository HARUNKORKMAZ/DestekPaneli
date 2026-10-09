using DestekPaneli.Domain.Common;

namespace DestekPaneli.Domain.Entities
{
    public class TicketMessage : BaseEntity
    {
        public string MessageText { get; set; } = default!;
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } = default!;

        public Guid SenderId { get; set; }
        public User Sender { get; set; }=default!;
    }
}
