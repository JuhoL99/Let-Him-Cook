using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    public AudioClip GetAudioClip()
    {
        return clip;
    }
}
