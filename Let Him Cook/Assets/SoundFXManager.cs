using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    public AudioSource source;
    public AudioSource bgMusic;
    public AudioClip bgClip;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        bgMusic.clip = bgClip;
        bgMusic.Play();
    }

    public void PlaySoundFX(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
