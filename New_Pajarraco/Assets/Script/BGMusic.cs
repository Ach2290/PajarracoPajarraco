using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioClip bgMusics;
    public float maxTime;

    private float currentTime;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = Audio.instance.PlayAudioOnLoop(bgMusics);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime || GameManager.Instance.isGameOver == true)
        {
            currentTime = 0;
            audioSource.Stop();
            audioSource = Audio.instance.PlayAudioOnLoop(bgMusics);
        }
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }
}