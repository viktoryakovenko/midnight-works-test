using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    private IEnumerator Start()
    {
        //Services initialization

        yield return null;

        SceneManager.LoadScene("Gameplay");
    }
}
