using System;

namespace Data
{
    [Serializable]
    public class AllMarketsData
    {
        public SerializableDictionary<string, MarketData> Markets = new SerializableDictionary<string, MarketData>();
    }
}
