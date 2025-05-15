using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ThingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator TheThing;
    public Transform playerTransform;

    public GameObject TriggerPrefab;
    public GameObject BlockPrefab;
    public GameObject DodgePrefab;
    public Transform[] spawnZone;

    public Transform targetPosition1;
    public Transform targetRotation1;


    private bool isFrozen = false;
    private float frozenTime = 0f;  // Store the frozen time

    void Start()
    {
        TheThing = GetComponent<Animator>();
        TheThing.speed = 0.0f;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position;
            targetPosition.y = transform.position.y; // Keep current Y level

            transform.LookAt(targetPosition);
        }
    }

    // This function is called when the Play Animation button is pressed
    public void PlayThing()
    {
        TheThing.speed = 1.0f;
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
        if (index == 0 || index == 1 || index == 2 || index == 3)
        {
            // Instantiate the trigger box at the specified spawn point
            GameObject spawnedTriggerBox = Instantiate(TriggerPrefab, spawnZone[index].position, spawnZone[index].rotation);
            spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>().playerTransform = playerTransform.transform;

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
        if (index == 4 || index == 6 || index == 7)
        {
            // Instantiate the trigger box at the specified spawn point
            GameObject spawnedTriggerBox = Instantiate(BlockPrefab, spawnZone[index].position, spawnZone[index].rotation);
            spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>().playerTransform = playerTransform.transform;

            // Get the TriggerBox script attached to the newly spawned trigger box
            ResumeAnimationTrigger triggerBoxScript = spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>();

            // If the TriggerBox script exists, assign the necessary references
            if (triggerBoxScript != null)
            {
                // Assign the references to the instantiated trigger box
                triggerBoxScript.ThingAnimation = this;  // Assign ThingAnimation to the trigger box
            }

            // Log the spawn information
            Debug.Log("HitBox spawned at: " + spawnZone[index].position);
        }
        if (index == 5)
        {
            // Instantiate the trigger box at the specified spawn point
            GameObject spawnedTriggerBox = Instantiate(DodgePrefab, spawnZone[index].position, spawnZone[index].rotation);
            spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>().playerTransform = playerTransform.transform;

            // Get the TriggerBox script attached to the newly spawned trigger box
            ResumeAnimationTrigger triggerBoxScript = spawnedTriggerBox.GetComponent<ResumeAnimationTrigger>();


            // If the TriggerBox script exists, assign the necessary references
            if (triggerBoxScript != null)
            {
                // Assign the references to the instantiated trigger box
                triggerBoxScript.ThingAnimation = this;  // Assign ThingAnimation to the trigger box
            }

            // Log the spawn information
            Debug.Log("DodgePrefab spawned at: " + spawnZone[index].position);
        }
    }
}


