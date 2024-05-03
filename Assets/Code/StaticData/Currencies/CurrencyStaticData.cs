using UnityEngine;

namespace StaticData.Currencies
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "StaticData/Currency")]
    public class CurrencyStaticData : ScriptableObject
    {
        public CurrencyTypeId CurrencyTypeId;
        public int Amount;
        public Sprite Sprite;
    }
}
