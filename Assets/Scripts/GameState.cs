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

    [SerializeField] private float gameTime;

    private void Awake()
    {
        Singleton = this;
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
        IsPlaying = true;
        Interface.Singleton.ShowTextIndicator();
    }
}
