using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip Slice;
    public AudioClip woosh;

    public static AudioController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
