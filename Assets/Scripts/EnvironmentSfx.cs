using UnityEngine;

public class EnvironmentSfx : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioSource doorAudioSource;
    public AudioClip openDoorClip;
    public AudioClip closeDoorClip;
    public void CreateDoorAudioIfNotPresent()
    {
        if (doorAudioSource == null)
        {
            doorAudioSource = gameObject.AddComponent<AudioSource>();
        }
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
        CreateDoorAudioIfNotPresent();
        StopDoorAudioIfPlaying();
        doorAudioSource.clip = closeDoorClip;
        doorAudioSource.Play();
    }
    public void PlayOpenDoor()
    {
        CreateDoorAudioIfNotPresent();
        StopDoorAudioIfPlaying();
        doorAudioSource.clip = openDoorClip;
        doorAudioSource.Play();
    }
}
