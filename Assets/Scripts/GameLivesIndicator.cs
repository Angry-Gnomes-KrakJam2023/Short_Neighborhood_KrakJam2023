using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLivesIndicator : MonoBehaviour
{
    public static GameLivesIndicator Singleton;

    [SerializeField] private TMP_Text text;

    public GameLivesIndicator()
    {
        Singleton = this;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
