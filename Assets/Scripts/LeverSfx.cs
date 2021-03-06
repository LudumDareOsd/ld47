﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSfx : MonoBehaviour
{
    public AudioSource leverPullAudioSource;
    private void Awake()
    {
        leverPullAudioSource.volume = 0.25f;
    }
    public void PlayPullLever()
    {
        if (leverPullAudioSource.isPlaying)
        {
            leverPullAudioSource.Stop();
        }
        leverPullAudioSource.Play();
    }
}
