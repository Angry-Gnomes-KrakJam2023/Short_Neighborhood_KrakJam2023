using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int mainSceneNumber;
    
    public static Menu Singleton {get; private set;}

    void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Play()
    {
        AsyncSceneLoader.Singleton.LoadScene(mainSceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
}