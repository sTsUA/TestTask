using ShipData;
using Ships.Ammo;
using UnityEngine;

namespace Ships.GunData
{
    public class Gun : GunBase
    {
        protected override float Dmg => dmg + CurLevel?.BonusDamage ?? 0;
        [SerializeField] private float dmg;

        [SerializeField] private float atkSpeed;

        [SerializeField] private AmmoBase ammoBase;
        [SerializeField] private int barrelsCount;
        [SerializeField] private int ammoCount;
        [SerializeField] private int reloadTime;

        [SerializeField] private GunLevelData[] levelDatas;
        protected GunLevelData CurLevel { get; private set; }

        public override void SetLevel(int level)
        {
            base.SetLevel(level);
            CurLevel = levelDatas[level - 1];
        }
        
        public override void DealDamage(IHPProvider target)
        {
            target.TakeDamage(Dmg);
        }

        public override object Clone()
        {
            var clone = (Gun)base.Clone();

            clone.ammoBase = (AmmoBase) ammoBase.Clone();
            
            return clone;
        }
    }
}