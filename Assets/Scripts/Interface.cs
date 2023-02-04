using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject textIndicator;
    [SerializeField] private GameObject livesIndicator;

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

    public void ShowLivesIndicator()
    {
        livesIndicator.SetActive(true);
    }

    public void HideLivesIndicator()
    {
        livesIndicator.SetActive(false);
    }
}
