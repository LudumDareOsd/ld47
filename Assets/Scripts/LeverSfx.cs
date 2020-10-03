using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSfx : MonoBehaviour
{
    public AudioSource leverPullAudioSource;
    public void PlayPullLever()
    {
        if (leverPullAudioSource.isPlaying)
        {
            leverPullAudioSource.Stop();
        }
        leverPullAudioSource.Play();
    }
}
