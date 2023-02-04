using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 0;

    public void OnClick()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(sceneIndex);
    }
}
