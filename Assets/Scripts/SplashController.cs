using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public float waitTime = 3f;
    void Start()
    {
        StartCoroutine(GotoNextScene());
    }

    IEnumerator GotoNextScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}
