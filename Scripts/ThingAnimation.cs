using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ThingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator TheThing;

    public GameObject TriggerPrefab;
    public Transform[] spawnZone;

    public Transform targetPosition1;
    public Transform targetRotation1;


    private bool isFrozen = false;
    private float frozenTime = 0f;  // Store the frozen time

    void Start()
    {
        TheThing = GetComponent<Animator>();
    }

    // This function is called when the Play Animation button is pressed
    public void PlayThing()
    {

        // Set the rotation to the target rotation
        transform.rotation = targetPosition1.rotation;

        // Play the animation by triggering it 
        TheThing.SetTrigger("PlayPunchCombo");
    }


    // This function will freeze the animation at the current time
    public void FreezeAnimation()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            frozenTime = TheThing.GetCurrentAnimatorStateInfo(0).normalizedTime;
            TheThing.speed = 0.0f;
            
            Debug.Log(" Animation Frozen at: " + frozenTime);
        }
    }

    // This function will resume the animation from the frozen point
    public void ResumeAnimationThing()
    {
        if (isFrozen)
        {
            isFrozen = false;
            TheThing.speed = 1f;
            Debug.Log("Unfrozen");
            //AnimatorStateInfo ThingInfo = TheThing.GetCurrentAnimatorStateInfo(0);
            //TheThing.Play(ThingInfo.fullPathHash, 0, frozenTime);
            //This part was reverting my animation back to previous state, bad
        }
    }

    public void SpawnTriggerBox(int index)
    {
        if (index < spawnZone.Length)
        {
            // Instantiate the trigger box at the specified spawn point
            GameObject spawnedTriggerBox = Instantiate(TriggerPrefab, spawnZone[index].position, spawnZone[index].rotation);

            // Get the TriggerBox script attached to the newly spawned trigger box
            ResumeAnimationTrigger triggerBoxScript = spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>();

            // If the TriggerBox script exists, assign the necessary references
            if (triggerBoxScript != null)
            {
                // Assign the references to the instantiated trigger box
                triggerBoxScript.ThingAnimation = this;  // Assign ThingAnimation to the trigger box
            }

            // Log the spawn information
            Debug.Log("Trigger Box spawned at: " + spawnZone[index].position);
        }
    }
}


