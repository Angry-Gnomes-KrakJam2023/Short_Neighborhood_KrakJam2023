using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string mainSceneName;
    
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
        SceneManager.LoadScene(mainSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}