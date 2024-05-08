using Code.Data;
using Infrastructure.Factory;
using Services;
using Services.Bank;
using Services.PersistentProgress;
using Services.SaveLoad;
using Services.StaticData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return RegisterServices();

        SceneManager.LoadScene("Gameplay");
    }

    private IEnumerator RegisterServices()
    {
        yield return RegisterStaticData();

        yield return ServiceLocator.RegisterServiceAsync<ISaveLoadService>(new SaveLoadService());
        yield return ServiceLocator.RegisterServiceAsync<IGameFactory>(new GameFactory(
            ServiceLocator.GetService<IMarketsStaticDataService>()
        ));
        yield return RegisterProgressService();
        yield return ServiceLocator.RegisterServiceAsync<IBankService>(new BankService(
            ServiceLocator.GetService<IPersistentProgressService>()
        ));
    }

    private IEnumerator RegisterStaticData()
    {
        IMarketsStaticDataService marketsDataService = new MarketsStaticDataService();
        marketsDataService.LoadMarkets();

        yield return ServiceLocator.RegisterServiceAsync(marketsDataService);
    }

    private IEnumerator RegisterProgressService()
    {
        yield return ServiceLocator.RegisterServiceAsync<IPersistentProgressService>(new PersistentProgressService());

        var progressLoader = new ProgressLoader(
            ServiceLocator.GetService<IPersistentProgressService>(), 
            ServiceLocator.GetService<ISaveLoadService>()
        );
        progressLoader.LoadProgressOrInitNew();

        yield return progressLoader;
    }
}
