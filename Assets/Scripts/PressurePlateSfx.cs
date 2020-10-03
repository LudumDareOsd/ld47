using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip activeClip;
    public AudioClip interClip;
    public AudioClip inactiveClip;
    private void StopAudioIfPlaying()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlayActiveSound()
    {
        PlayClip(activeClip);
    }
    public void PlayInterSound()
    {
        PlayClip(interClip);
    }
    public void PlayInactiveSound()
    {
        PlayClip(inactiveClip);
    }
}
