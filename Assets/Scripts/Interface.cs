using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject textIndicator;

    public static Interface Singleton { get; private set; }
    
    void Awake()
    {
        if (!Singleton)
            Singleton = this;
        else
            Destroy(this.gameObject);
    }

    public void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowTextIndicator()
    {
        textIndicator.SetActive(true);
    }

    public void HideTextIndicator()
    {
        textIndicator.SetActive(false);
    }
    
}
