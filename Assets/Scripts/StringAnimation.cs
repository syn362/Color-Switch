using UnityEngine;
using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class StringAnimation : MonoBehaviour
{
    public GameObject Loading;

    public static Action OnAnimationEnd;

    public float Delay = 0.55f;

    public Text label;

    public string text;

    private float IntervalTime = 0.05f;

    void OnEnable()
    {
        label.text = "";
        Invoke("FreeLevelLoad", Delay + text.Length * IntervalTime + 2);
        if (Delay > 0)
        {
            StartCoroutine("Animate");
        }
    }

    public void StartAnimate()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        label.text = "";
        if (Delay > 0)
            yield return new WaitForSeconds(Delay);

        for (int i = 0; i < text.Length; i++)
        {
            label.text += text[i];
            yield return new WaitForSeconds(IntervalTime);
        }
    }

    void FreeLevelLoad()
    {
        if (OnAnimationEnd != null)
        {
            OnAnimationEnd();
        }
        Loading.SetActive(true);
    }

}