using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAnimationTrigger : MonoBehaviour
{
    public AnimationController AnimationController;

    public ThingAnimation ThingAnimation;
    //Either use different class name or keep it seperate

    public AudioClip PunchEffect;
    public AudioClip GruntEffect;
    public Transform playerTransform;

    public float delay = 5f;

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetPos = playerTransform.position;
            targetPos.y = transform.position.y;
            transform.LookAt(targetPos);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player or the object with the Animator
        if (other.CompareTag("Player"))
        {

            ThingAnimation.ResumeAnimationThing();
            Debug.Log(" Animation Resumed by trigger box!");
            AudioSource.PlayClipAtPoint(GruntEffect, transform.position);
            AudioSource.PlayClipAtPoint(PunchEffect, transform.position);


            Destroy(gameObject);
        }
        else
        {
            //Destroy (gameObject, delay);
        }
    }
}

