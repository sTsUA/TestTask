namespace Ships.SlotData
{
    public interface ISlot
    {
        bool TryPutItem(ISlotItem slotItem);
        void ReleaseSlot();
    }
}