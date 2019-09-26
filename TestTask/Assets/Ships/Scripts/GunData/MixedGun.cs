using ShipData;
using UnityEngine;

namespace Ships.GunData
{
    public class MixedGun : GunBase
    {
        [SerializeField] private Gun firstGun;
        [SerializeField] private Gun secondGun;
        
        public override void DealDamage(IHPProvider target)
        {
            firstGun.DealDamage(target);
            secondGun.DealDamage(target);
        }

        public override object Clone()
        {
            var clone = (MixedGun)base.Clone();

            clone.firstGun = (Gun)firstGun.Clone();
            clone.secondGun = (Gun)secondGun.Clone();
            
            return clone;
        }
    }
}