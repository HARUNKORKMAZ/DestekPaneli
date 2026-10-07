using Ardalis.SmartEnum;

namespace DestekPaneli.Domain.Enums
{
    public sealed class PriorityLevelEnum : SmartEnum<PriorityLevelEnum, string>
    {
        public static readonly PriorityLevelEnum Low = new("Low", "Düşük");
        public static readonly PriorityLevelEnum Medium = new("Medium", "Orta");
        public static readonly PriorityLevelEnum High = new("High", "Yüksek");

        private PriorityLevelEnum(string name, string value) : base(name, value) { }
    }
}
