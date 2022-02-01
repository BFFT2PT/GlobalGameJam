using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingMusic : MonoBehaviour
{
    public static FadingMusic instance;

    AudioSource backgroundMusic;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    public void StartFadingMusic()
    {
        StartCoroutine("LowerVolume");
    }

    IEnumerator LowerVolume()
    {
        while(backgroundMusic.volume > 0)
        {
            backgroundMusic.volume -= 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
