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
                GameTimeIndicator.Singleton.SetText(((int)gameTime / 60).ToString("N0") + ":" + ((int)gameTime % 60).ToString("N0"));
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
        }
    }

    private float gameTime;
    private int lives;

    private void Awake()
    {
        Singleton = this;
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
}
