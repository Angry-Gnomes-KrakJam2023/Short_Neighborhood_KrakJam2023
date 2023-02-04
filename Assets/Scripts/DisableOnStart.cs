using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }
}
