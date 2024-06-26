using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource ClickSFX;

    public void Pressed_OnButton()
    {
        ClickSFX.Play();
    }
}
