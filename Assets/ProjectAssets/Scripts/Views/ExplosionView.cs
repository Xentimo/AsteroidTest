using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class ExplosionView : MonoBehaviour
{
    public AudioClip sound;
    public void Explode(Action onBurnOut)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        StartCoroutine(BurnOut(onBurnOut));
    }

    IEnumerator BurnOut(Action onBurnOut)
    {
        yield return new WaitForSeconds(0.3f);
        onBurnOut?.Invoke();
    }
}
