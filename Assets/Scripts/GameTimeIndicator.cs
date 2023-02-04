using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeIndicator : MonoBehaviour
{
    public static GameTimeIndicator Singleton;

    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        Singleton = this;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
