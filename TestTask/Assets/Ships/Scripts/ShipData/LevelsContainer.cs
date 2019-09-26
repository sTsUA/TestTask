using UnityEngine;
using Utils;

namespace ShipData
{
    public class LevelsContainer : ScriptableObject
    {
        [SerializeField] private ShipLevelData[] shipLevels;

        public ShipLevelData GetShipLevel(int level) => shipLevels.GetItemSafe(level - 1);
    }
}