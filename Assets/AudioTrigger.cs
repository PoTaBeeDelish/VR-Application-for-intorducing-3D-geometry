using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    // Method triggered when another Collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Play the audio if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    // Method triggered when another Collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Stop the audio if needed when the object exits the trigger

        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
