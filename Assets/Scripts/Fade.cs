using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade Singleton { get; private set; }
    [SerializeField] private AnimationCurve fadeCurve;

    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        Singleton = this;
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(IEFade(1f, 0f));
    }

    public void FadeOut()
    {
        StartCoroutine(IEFade(0f, 1f));
    }
    
    IEnumerator IEFade(float start, float finish)
    {
        fadeImage.color = new Color (0, 0,0, start);
        float lerp = 0f;
        while (Math.Abs(fadeImage.color.a - finish) > 0.02f)
        {
            fadeImage.color = new Color (0, 0,0, Mathf.Lerp(start, finish, fadeCurve.Evaluate(lerp)));
            lerp += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
