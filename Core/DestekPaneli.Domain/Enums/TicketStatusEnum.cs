using Ardalis.SmartEnum;

namespace DestekPaneli.Domain.Enums
{
    public sealed class TicketStatusEnum : SmartEnum<TicketStatusEnum, string>
    {
        public static readonly TicketStatusEnum Open = new("Open", "Açık");
        public static readonly TicketStatusEnum InProgress = new("InProgress", "Devam Ediyor");
        public static readonly TicketStatusEnum Closed = new("Closed", "Kapandı");

        private TicketStatusEnum(string name, string value) : base(name, value) { }
    }
}
