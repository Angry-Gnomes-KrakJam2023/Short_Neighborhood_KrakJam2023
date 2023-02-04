using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLivesIndicator : MonoBehaviour
{
    public static GameLivesIndicator Singleton;

    [SerializeField] private GameObject heartPrefab;

    public GameLivesIndicator()
    {
        Singleton = this;
    }

    public void SetLives(int amount)
    {
        for(int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
        for(int i = 0; i < amount; i++)
            Instantiate(heartPrefab, transform);
    }
}
