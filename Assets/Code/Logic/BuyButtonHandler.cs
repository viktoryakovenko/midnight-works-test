using Data;
using Infrastructure.Factory;
using Services;
using Services.PersistentProgress;
using StaticData.Markets;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    private IGameFactory _gameFactory;
    private IPersistentProgressService _progressService;
    private MarketTypeId _typeId;
    private Transform _marketSpawnPoint;
    private string _marketId;

    private void Awake()
    {
        _progressService = ServiceLocator.GetService<IPersistentProgressService>();
        _gameFactory = ServiceLocator.GetService<IGameFactory>();
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
        GameObject market = _gameFactory.CreateMarket(_typeId, _marketSpawnPoint);
        MarketData data = new MarketData();
        data.Id = _marketId;
        data.CurrentLevel = 1;
        _progressService.Progress.MarketsData.Add(data);

        Destroy(gameObject);
    }
}
