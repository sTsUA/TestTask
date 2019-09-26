namespace Ships.SlotData
{
    public interface ISlotItem
    {
        SlotType TargetSlot { get; }
        void SetSlot(ISlot slot);
    }
}