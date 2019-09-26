using System;
using ShipData;
using Ships.SlotData;
using UnityEngine;

namespace Ships
{
    public class SlotItemBase : ScriptableObject, IHPProvider, ISlotItem, ICloneable
    {
        [SerializeField] private SlotType targetSlot;

        public float HP => hp;
        [SerializeField] private float hp;
       
        public SlotType TargetSlot => targetSlot;
        public ISlot CurSlot { get; private set; }
        
        public void SetSlot(ISlot slot)
        {
            CurSlot = slot;
        }

        public virtual void SetLevel(int level){}
        
        public virtual void TakeDamage(float amount)
        {
            hp -= amount;
            
            //Если вещь в слоте умирает, освобождается слот
            if (hp <= 0)
                CurSlot?.ReleaseSlot();
        }

        public virtual object Clone()
        {
            return Instantiate(this);
        }
    }
}