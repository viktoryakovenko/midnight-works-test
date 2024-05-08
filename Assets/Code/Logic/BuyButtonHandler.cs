using Data;
using Infrastructure.Factory;
using Services;
using Services.Bank;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.Markets;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    private IGameFactory _gameFactory;
    private IPersistentProgressService _progressService;
    private IBankService _bankService;
    private MarketTypeId _typeId;
    private Transform _marketSpawnPoint;
    private string _marketId;

    private void Awake()
    {
        _progressService = ServiceLocator.GetService<IPersistentProgressService>();
        _gameFactory = ServiceLocator.GetService<IGameFactory>();
        _bankService = ServiceLocator.GetService<IBankService>();
    }

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(CreateMarket);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(CreateMarket);
    }

    public void Initialize(MarketTypeId typeId, Transform spawnPoint, string marketId)
    {
        _typeId = typeId;
        _marketSpawnPoint = spawnPoint;
        _marketId = marketId;
    }

    private void CreateMarket()
    {
        InitMarketData();
        HandleBank();

        _gameFactory.CreateMarket(_typeId, _marketSpawnPoint, _marketId);

        Destroy(gameObject);
    }

    private void InitMarketData()
    {
        MarketData data = new MarketData();
        data.Id = _marketId;
        data.CurrentLevel = 1;
        _progressService.Progress.MarketsData.Add(data);
    }

    private void HandleBank()
    {
        var marketStaticData = ServiceLocator.GetService<IMarketsStaticDataService>();
        _bankService.WithdrawCoins(marketStaticData.ForMarket(_typeId).BaseCost);
    }
}
