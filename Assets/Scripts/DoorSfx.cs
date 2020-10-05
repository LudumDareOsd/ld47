using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSfx : MonoBehaviour
{
    public AudioSource doorAudioSource;
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;
    private void Awake()
    {
    }
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
        doorAudioSource.volume = 0.1f;
        doorAudioSource.clip = closeDoorClip;
        doorAudioSource.Play();
    }
    public void PlayOpenDoor()
    {
        StopDoorAudioIfPlaying();
        doorAudioSource.volume = 0.4f;
        doorAudioSource.clip = openDoorClip;
        doorAudioSource.Play();
    }
}
