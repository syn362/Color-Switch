using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private Music music;
    public GameObject MusicToggleIcon;
    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    void Start()
    {
        music = GameObject.FindObjectOfType<Music>();
        UpdateIconAndVolumeMusic();
    }

    public void StopMusic()
    {
        music.ToggleSound();
        UpdateIconAndVolumeMusic();
    }

    public void UpdateIconAndVolumeMusic()
    {
        if (PlayerPrefs.GetInt("Muted",0) == 0)
        {
            AudioListener.volume = 1;
            MusicToggleIcon.GetComponent<Image>().sprite = MusicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            MusicToggleIcon.GetComponent<Image>().sprite = MusicOffSprite;
        }
    }
}
