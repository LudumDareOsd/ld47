using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip activeClip;
    public float activeClipVolume = 0.35f;
    public AudioClip interClip;
    public float interClipVolume = 0.15f;
    public AudioClip inactiveClip;
    public float inactiveClipVolume = 0.15f;
    private void StopAudioIfPlaying()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    private void PlayClip(AudioClip clip, float volume)
    {
        StopAudioIfPlaying();
        audioSource.volume = volume;
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void PlayActiveSound()
    {
        PlayClip(activeClip, activeClipVolume);
    }
    public void PlayInterSound()
    {
        PlayClip(interClip, interClipVolume);
    }
    public void PlayInactiveSound()
    {
        PlayClip(inactiveClip, inactiveClipVolume);
    }
}
