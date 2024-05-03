using UnityEngine;

namespace StaticData.Markets
{
    [CreateAssetMenu(fileName = "MarketData", menuName = "StaticData/Market")]
    public class MarketStaticData : ScriptableObject
    {
        public MarketTypeId MarketTypeId;
        [Min(0)] public int BaseCost;
        [Min(0)] public int UpgradeCost;
        [Min(0)] public int BaseTime;
        [Min(0)] public int CurrentLevel;
        public GameObject Prefab;
    }
}
