using System;
using UnityEngine;

namespace Ships.GunData
{
    [Serializable]
    public class GunLevelData : ICloneable
    {
        public float BonusDamage;
        
        public object Clone()
        {
            return new GunLevelData { BonusDamage = BonusDamage};
        }
    }
}