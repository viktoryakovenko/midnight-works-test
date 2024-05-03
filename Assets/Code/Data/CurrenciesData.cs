using StaticData.Currencies;
using System;

namespace Data
{
    [Serializable]
    public class CurrenciesData
    {
        public SerializableDictionary<CurrencyTypeId, int> Currencies;
    }
}
