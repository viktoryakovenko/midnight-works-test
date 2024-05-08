using StaticData.Markets;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateMarket(MarketTypeId typeId, Transform parent, string id);
    }
}