using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Singleton { get; private set; }

    public static bool paused;
    public float HealthMultiplier => 1f + (GameTime / 15) * 0.1f;
    public float MothSpeed => 0.4f + 0.1f * (GameTime / 60);
    public int EnemyDamage => (int)(1 + GameTime / 60);
    public float SpawnerTime
    {
        get
        {
            float min = 4f - 0.1f * (GameTime / 10);
            if (min < 1.5f)
                min = 1.5f;
            float max = 8f - 0.2f * (GameTime / 10);
            if (max < 1.5f)
                max = 1.5f;

            return UnityEngine.Random.Range(min, max);
        }
    }

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
            GameLivesIndicator.Singleton.SetLives(lives);
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
        paused = false;

        Singleton = this;
        OnPlayerDeath += () => {
            StartCoroutine(DelayedPlayerDeath());
        };
    }

    private IEnumerator DelayedPlayerDeath()
    {
        yield return new WaitForSecondsRealtime(1f);
        Fade.Singleton.FadeOut();
        yield return new WaitForSecondsRealtime(1.2f);
        StopGame();
        Interface.Singleton.ShowGameOverScreen();
        Flashlight.Singleton.IsBlocked = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        yield return new WaitForSecondsRealtime(0.34f);
        Fade.Singleton.FadeIn();
    }

    private void Start()
    {
        StartGame();
    }

    private void FixedUpdate()
    {
        if (IsPlaying)
            GameTime += Time.fixedDeltaTime;
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
        Time.timeScale = 0f;
        var sources = FindObjectsOfType<AudioSource>();
        foreach (var source in sources)
            source.Stop();
    }

    public void PauseGame()
    {
        if (!IsPlaying)
            return;
        
        Interface.Singleton.ShowPauseMenu();
        var sources = FindObjectsOfType<AudioSource>();
        foreach (var source in sources)
            source.Pause();
        Time.timeScale = 0f;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        if (!IsPlaying)
            return;
        
        Interface.Singleton.HidePauseMenu();
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        var sources = FindObjectsOfType<AudioSource>();
        foreach (var source in sources)
            source.UnPause();
    }
}
