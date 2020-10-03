using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSfx : MonoBehaviour
{
    public AudioSource doorAudioSource;
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;
    public void StopDoorAudioIfPlaying()
    {
        if (doorAudioSource.isPlaying)
        {
            doorAudioSource.Stop();
        }
    }
    public void PlayCloseDoor()
    {
        StopDoorAudioIfPlaying();
        doorAudioSource.clip = closeDoorClip;
        doorAudioSource.Play();
    }
    public void PlayOpenDoor()
    {
        StopDoorAudioIfPlaying();
        doorAudioSource.clip = openDoorClip;
        doorAudioSource.Play();
    }
}
