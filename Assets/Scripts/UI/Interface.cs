using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject textIndicator;
    [SerializeField] private GameObject livesIndicator;
    [SerializeField] private Panel pausePanel;
    [SerializeField] private AudioSource gameOverSource;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text bestScore;

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
        score.text = ((int)(GameState.Singleton.GameTime / 60)).ToString("D2") + ":" +
                     ((int)(GameState.Singleton.GameTime % 60)).ToString("D2");
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        if (GameState.Singleton.GameTime > bestScore)
        {
            bestScore = (int)GameState.Singleton.GameTime;
            PlayerPrefs.SetInt("bestScore", (int)GameState.Singleton.GameTime);
        }

        this.bestScore.text = "Best: " + ((int)(bestScore / 60)).ToString("D2") + ":" + ((int)(bestScore % 60)).ToString("D2");
        gameOverSource.Play();
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

    public void ShowPauseMenu()
    {
        pausePanel.ShowPanel();
    }

    public void HidePauseMenu()
    {
        pausePanel.HidePanel();
    }
}
