using StaticData.Markets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.StaticData
{
    public class MarketsStaticDataService : IMarketsStaticDataService
    {
        private Dictionary<MarketTypeId, MarketStaticData> _markets;

        public void LoadMarkets()
        {
            _markets = Resources
                .LoadAll<MarketStaticData>("StaticData/Markets")
                .ToDictionary(x => x.MarketTypeId, x => x);
        }

        public MarketStaticData ForMarket(MarketTypeId typeId) =>
            _markets.TryGetValue(typeId, out MarketStaticData staticData)
                ? staticData
                : null;
    }
}
