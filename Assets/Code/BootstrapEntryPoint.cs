using Services;
using Services.SaveLoad;
using Services.StaticData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return InitServices();

        SceneManager.LoadScene("Gameplay");
    }

    private IEnumerator InitServices()
    {
        yield return ServiceLocator.RegisterServiceAsync(new SaveLoadService());

        CurrenciesStaticDataService currenciesDataService = new CurrenciesStaticDataService();
        currenciesDataService.LoadCurrencies();

        MarketsStaticDataService marketsDataService = new MarketsStaticDataService();
        marketsDataService.LoadMarkets();

        yield return ServiceLocator.RegisterServiceAsync(currenciesDataService);
        yield return ServiceLocator.RegisterServiceAsync(marketsDataService);
    }
}
