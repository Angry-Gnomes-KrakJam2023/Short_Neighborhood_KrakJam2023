using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Distractor>(out Distractor distractor))
        {
            if (distractor != null)
            {
                MothScreen.Singleton.PlayAnimation();
                StartCoroutine(stopAnimationAfterTime(MothScreen.Singleton.animationTime));
                Destroy(other.gameObject);
            }
        }
    }

    IEnumerator stopAnimationAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        MothScreen.Singleton.StopAnimation();
    }
}
