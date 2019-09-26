using Ships.SlotData;
using UnityEngine;

namespace ShipData
{
    /// <summary>
    /// Пресет корабля
    /// </summary>
    public class ShipPreset : ScriptableObject
    {
        public int ShipStartLevel;
        public SlotPreset LightSlot;
        public SlotPreset MediumSlot;
        public SlotPreset HeavySlot;

        public void ApplyLevels()
        {
            LightSlot.ItemBase.SetLevel(LightSlot.StartLevel);
            MediumSlot.ItemBase.SetLevel(MediumSlot.StartLevel);
            HeavySlot.ItemBase.SetLevel(HeavySlot.StartLevel);
        }

        #if UNITY_EDITOR
        private void OnValidate()
        {
            ValidateSlot(LightSlot, SlotType.Light);
            ValidateSlot(MediumSlot, SlotType.Med);
            ValidateSlot(HeavySlot, SlotType.Heavy);
            
            //Проверка чтоб в слот нельзя было поставить итем который не для этого слота
            void ValidateSlot(SlotPreset curSlot, SlotType targetType)
            {
                if (curSlot.ItemBase != null && curSlot.ItemBase.TargetSlot != targetType)
                {
                    Debug.LogError($"{targetType} slot cant store item {curSlot.ItemBase.name} because item has type {curSlot.ItemBase.TargetSlot}");
                    curSlot.ItemBase = null;
                }
            }
        }
        #endif
    }
}