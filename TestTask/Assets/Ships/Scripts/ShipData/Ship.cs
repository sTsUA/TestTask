using Ships.Equip;
using Ships.GunData;
using Ships.SlotData;
using UnityEngine;
using Zenject;

namespace ShipData
{
    public class Ship : MonoBehaviour, IHPProvider
    {
        public float HP { get; private set; }
        private Slot[] _slots;
        private ShipLevelData _levelData;

        [Inject] private LevelsContainer _levelStorage;

        private Gun _curGun;

        [SerializeField] private ShipPreset preset;

        private void Awake()
        {
            _slots = new [] { new Slot(SlotType.Light), new Slot(SlotType.Med), new Slot(SlotType.Heavy) };
            HP = 100;
            
            _levelData = _levelStorage.GetShipLevel(1);
        }

        private void Start()
        {
            LoadPreset();
        }

        void LoadPreset()
        {
            if(preset == null) return;
            
            preset.ApplyLevels();
            
            TrySetItemToSlot(preset.LightSlot.ItemBase);
            TrySetItemToSlot(preset.MediumSlot.ItemBase);
            TrySetItemToSlot(preset.HeavySlot.ItemBase);
            
            _levelData = _levelStorage.GetShipLevel(preset.ShipStartLevel);
        }
        
        public void TakeDamage(float amount)
        {
            HP -= amount;

            if (HP <= 0)
            {
                DestroyShip();
            }
        }

        private void DestroyShip()
        {
            //Корабль умирает
            for (int i = 0; i < _slots.Length; i++)
                _slots[i].ReleaseSlot();
        }

        /// <summary>
        /// Ставим предмет в слот
        /// </summary>
        public bool TrySetItemToSlot(ISlotItem slotItem)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].TryPutItem(slotItem))
                    return true;
            }
            
            return false;
        }

        /// <summary>
        /// Функция инициализации корабля перед стартом боя
        /// </summary>
        public void BattleStart()
        {
            FindGun();
            ApplyEquip();
        }

        /// <summary>
        /// Функция поиска текущей пушки на корабле
        /// </summary>
        void FindGun()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i].SlotItem != null && _slots[i].SlotItem is Gun gun)
                {
                    _curGun = gun;
                    break;
                }
            }
        }

        void ApplyEquip()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if(_slots[i].SlotItem == null) continue;

                var equip = _slots[i].SlotItem as SlotEquipBase;
                equip?.ApplyEquip(this);
            }
        }

        public void Shoot(IHPProvider target)
        {
            if(_curGun == null) return;
            
            _curGun.DealDamage(target);
        }
    }
}