using ShipData;

namespace Ships.GunData
{
    public abstract class GunBase : SlotItemBase
    {
        protected virtual float Dmg { get; }

        public abstract void DealDamage(IHPProvider target);
    }
}