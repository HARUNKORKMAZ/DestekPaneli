using Ardalis.SmartEnum;
using DestekPaneli.Domain.Common;
using DestekPaneli.Domain.Enums;

namespace DestekPaneli.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public TicketStatusEnum TicketStatus { get; set; } = TicketStatusEnum.InProgress;
        public PriorityLevelEnum Priority { get; set; } = PriorityLevelEnum.Low;
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<TicketMessage> Messages { get; set; }

    }
}
