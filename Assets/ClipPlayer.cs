using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClipPlayer : MonoBehaviour
{
    public AudioClip[] possibleClips;
    public AudioSource source;
    public float volume = 1f;
    public bool playOnAwake = false;

    private void Awake()
    {
        if (playOnAwake)
        {
            Play();
        }
    }

    public void Play()
    {
        var selectedClip = Random.Range(0, possibleClips.Length);
        source.PlayOneShot(possibleClips[selectedClip],volume);
    }
}
