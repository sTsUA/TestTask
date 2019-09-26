using UnityEngine;

namespace Ships.Ammo
{
    public class BulletsAmmo : AmmoBase
    {
        [SerializeField] private float dmgMultiplier;

        public override object Clone()
        {
            return Instantiate(this);
        }
    }
}