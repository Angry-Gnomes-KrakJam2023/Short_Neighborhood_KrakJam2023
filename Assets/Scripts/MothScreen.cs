using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MothScreen : MonoBehaviour
{
    public List<Sprite> Frames;
    public float animationTime = 7f;
    [SerializeField] private float frameTime;

    public static MothScreen Singleton { get; private set; }
    public bool IsPlaying { get; private set; } = false;

    private int currentFrame = 0;
    private Image image;

    public MothScreen()
    {
        Singleton = this;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void PlayAnimation()
    {
        if (IsPlaying)
            return;

        gameObject.SetActive(true);
        IsPlaying = true;
        StartCoroutine(animLoop());
    }

    public void StopAnimation()
    {
        if (!IsPlaying)
            return;

        gameObject.SetActive(false);
        IsPlaying = false;
    }

    IEnumerator animLoop()
    {
        if(!IsPlaying)
            yield break;
        
        while(IsPlaying)
        {
            currentFrame++;
            currentFrame %= Frames.Count;
            image.sprite = Frames[currentFrame];

            yield return new WaitForSeconds(frameTime);
        }
    }
}
