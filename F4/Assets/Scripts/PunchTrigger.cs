using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTriggerZone : MonoBehaviour
{
    public Animator AnimationController;

    public ThingAnimation ThingPunchAnimation;
    private bool hasTriggered = false; // Prevents multiple triggers

    void Start()
    {
        AnimationController = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; 
            AnimationController.speed = 1.0f;
            AnimationController.SetTrigger("PlayPunchCombo");
            Debug.Log("Punch Triggered by: " + other.name);
            //StartCoroutine(ResetTrigger(3f)); // Reset after 3 seconds
        }
    }
    /*IEnumerator ResetTrigger(float delay)
    {
        yield return new WaitForSeconds(delay);
        hasTriggered = false;
    }*/

}
