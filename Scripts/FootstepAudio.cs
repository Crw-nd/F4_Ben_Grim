using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRFootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepSound;
    public CharacterController characterController;

    public float stepInterval = 0.5f; // Time between steps
    private float stepTimer = 0f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        audioSource.clip = footstepSound;
        audioSource.loop = false; // Ensure footsteps play one at a time
    }

    void Update()
    {
        if (characterController != null && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                audioSource.PlayOneShot(footstepSound);
                stepTimer = 0f; // Reset timer
            }
        }
        else
        {
            stepTimer = 0f; // Reset timer when stopped
        }
    }
}

