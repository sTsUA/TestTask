using System;
using UnityEngine;

namespace Ships.SlotData
{
    [Serializable]
    public class Slot : ISlot
    {
        public SlotType SlotType => slotType;
        [SerializeField] private SlotType slotType;

        public ISlotItem SlotItem { get; private set; }
        
        public Slot(SlotType slotType) => this.slotType = slotType;
        
        /// <summary>
        /// Предмет ставится в слот
        /// </summary>
        public bool TryPutItem(ISlotItem slotItem)
        {
            //Если слот пустой и соответствует слоту предмета
            if (SlotItem != null || slotItem.TargetSlot != slotType) return false;

            SlotItem = slotItem;
            SlotItem.SetSlot(this);
            
            return true;
        }

        public void ReleaseSlot()
        {
            SlotItem?.SetSlot(null);
            SlotItem = null;
        }
    }

    public enum SlotType{ None, Light, Med, Heavy }
}