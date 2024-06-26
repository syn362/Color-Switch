using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameBackButton : MonoBehaviour
{
    public GameObject PausePanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale=0;
            PausePanel.SetActive(true);
            
        }      
       
    }
}
