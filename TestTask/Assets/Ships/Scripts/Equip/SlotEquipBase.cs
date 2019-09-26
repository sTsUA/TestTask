using System;
using ShipData;
using Ships.SlotData;
using UnityEngine;
using Utils;

namespace Ships.Equip
{
    abstract class SlotEquipBase : SlotItemBase
    {
        [SerializeField] private EquipLevelData[] levelDatas;
        protected EquipLevelData CurLevel { get; private set; }

        public override void SetLevel(int level)
        {
            base.SetLevel(level);
            CurLevel = levelDatas.GetItemSafe(level - 1);
        }

        public abstract void ApplyEquip(Ship ship);
    }
}