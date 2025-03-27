using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundeffect : MonoBehaviour
{
    public AudioClip soundEffect;  // Drag sound effect here

    void Start()
    {
        if (soundEffect != null)
        {
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        }
        else
        {
            Debug.LogWarning("No sound effect");
        }
    }
}