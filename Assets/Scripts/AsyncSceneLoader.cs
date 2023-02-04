using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{

    public static AsyncSceneLoader Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(AsyncLoad(sceneNumber));
    }

    IEnumerator AsyncLoad(int sceneNumber)
    {
        Fade.Singleton.FadeOut();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneNumber);
    }
}
