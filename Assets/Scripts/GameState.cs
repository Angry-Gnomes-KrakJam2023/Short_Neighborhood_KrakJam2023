using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Singleton { get; private set; }

    public float GameTime
    {
        get => gameTime;
        private set
        {
            gameTime = value;
            if (GameTimeIndicator.Singleton != null)
                GameTimeIndicator.Singleton.SetText(((int)gameTime / 60).ToString("D2") + ":" + ((int)gameTime % 60).ToString("D2"));
        }
    }
    public bool IsPlaying { get; private set; }
    public int Lives
    {
        get => lives;
        set
        {
            lives = value;
            GameLivesIndicator.Singleton.SetText(lives.ToString("N0"));
            if (lives <= 0)
                OnPlayerDeath?.Invoke();
        }
    }
    public Action OnPlayerDeath { get; set; }

    private float gameTime;
    private int lives;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Singleton = this;
        OnPlayerDeath += () => {
            Interface.Singleton.ShowGameOverScreen();
            StopGame();
            Flashlight.Singleton.IsBlocked = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        };
    }

    private void Start()
    {
        StartGame();
    }

    private void FixedUpdate()
    {
        if (IsPlaying)
            GameTime += Time.fixedUnscaledDeltaTime;
    }

    public void StartGame()
    {
        GameTime = 0f;
        Lives = 3;
        IsPlaying = true;
        Interface.Singleton.ShowTextIndicator();
        Interface.Singleton.ShowLivesIndicator();
    }

    public void StopGame()
    {
        Interface.Singleton.HideLivesIndicator();
        Interface.Singleton.HideTextIndicator();
        IsPlaying = false;
    }
}
