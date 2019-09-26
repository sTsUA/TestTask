using System;
using Ships.GunData;

namespace Ships.SlotData
{
    /// <summary>
    /// Пресет итема в слоте
    /// </summary>
    [Serializable]
    public class SlotPreset
    {
        public int StartLevel;
        public SlotItemBase ItemBase;
    }
}