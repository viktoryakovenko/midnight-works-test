using Code.Data;
using Services;
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
        yield return LoadProgress();

        SceneManager.LoadScene("Gameplay");
    }

    private IEnumerator RegisterServices()
    {
        yield return RegisterStaticData();

        yield return ServiceLocator.RegisterServiceAsync<ISaveLoadService>(new SaveLoadService());
        yield return ServiceLocator.RegisterServiceAsync<IPersistentProgressService>(new PersistentProgressService());
        
    }

    private IEnumerator RegisterStaticData()
    {
        ICurrenciesStaticDataService currenciesDataService = new CurrenciesStaticDataService();
        currenciesDataService.LoadCurrencies();

        IMarketsStaticDataService marketsDataService = new MarketsStaticDataService();
        marketsDataService.LoadMarkets();

        yield return ServiceLocator.RegisterServiceAsync(currenciesDataService);
        yield return ServiceLocator.RegisterServiceAsync(marketsDataService);
    }

    private IEnumerator LoadProgress()
    {
        var progressLoader = new ProgressLoader(ServiceLocator.GetService<IPersistentProgressService>(), ServiceLocator.GetService<ISaveLoadService>());
        progressLoader.LoadProgressOrInitNew();

        yield return progressLoader;
    }
}
