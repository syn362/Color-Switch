using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Pressed_StartBTN()
    {
        SceneManager.LoadScene(2);
    }
}
