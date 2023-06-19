using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundtrack : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundtrack()
    {
        audioSource.Play();
    }

    public void StopSoundtrack()
    {
        audioSource.Stop();
    }
}
