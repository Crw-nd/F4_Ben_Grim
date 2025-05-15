using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;  // For UI button

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    //private Animator TheThing;
    public Transform targetPosition;
    public Transform targetRotation;

    private bool isFrozen = false;
    private float frozenTime = 0f;  // Store the frozen time

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component
        //TheThing = GetComponent<Animator>();
    }

    // This function is called when the Play Animation button is pressed
    public void PlayAnimationAtTargetPosition()
    {
        // Set the rotation to the target rotation
        transform.rotation = targetPosition.rotation;

        // Play the animation by triggering it 
        animator.SetTrigger("PlayAnimation");
    }

    //public void PlayThing()
    //{

    //    // Set the rotation to the target rotation
    //    transform.rotation = targetPosition.rotation;

    //    // Play the animation by triggering it 
    //    TheThing.SetTrigger("PlayPunchCombo");
    //}



    // This function will freeze the animation at the current time
    public void FreezeAnimation()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            frozenTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime; // Store the current time
            animator.speed = 0f; // Freeze the animation
            //frozenTime = TheThing.GetCurrentAnimatorStateInfo(0).normalizedTime;
            //TheThing.speed = 0f;
        }
    }

    // This function will resume the animation from the frozen point
    public void ResumeAnimation()
    {
        if (isFrozen)
        {
            isFrozen = false;
            animator.speed = 1f;  // Resume the animation by setting speed to 1
            Debug.Log("Unfrozen");
            // Get the current state and resume from the frozen time
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            animator.Play(stateInfo.fullPathHash, 0, frozenTime);  // Resume the animation from the frozen time
            //AnimatorStateInfo ThingInfo = TheThing.GetCurrentAnimatorStateInfo(0);
            //TheThing.Play(ThingInfo.fullPathHash, 0, frozenTime);
        }
    }
}

