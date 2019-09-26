using UnityEngine;

namespace Ships.Ammo
{
    public class LaserBeamAmmo : AmmoBase
    {
        [SerializeField] private float atkRangeMultiplier;

        public override object Clone()
        {
            return ScriptableObject.Instantiate(this);
        }
    }
}