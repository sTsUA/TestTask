using System;
using UnityEngine;

namespace Ships.Equip
{
    [Serializable]
    public class EquipLevelData : ICloneable
    {
        public float Amount;
        
        public object Clone()
        {
            return new EquipLevelData{Amount = Amount};
        }
    }
}