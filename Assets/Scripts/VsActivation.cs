using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VsActivation : MonoBehaviour
{
    AudioSource thisAudio;

    private void Start()
    {
        thisAudio = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        thisAudio.Play();
    }
}
