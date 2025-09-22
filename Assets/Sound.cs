using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource source;
    private void Start()
    {
        source = Music.instance.GetComponent<AudioSource>();
    }

    public void SoundOn()
    {
        source.volume = 0.1f;
    }
    public void SoundOff()
    {
        source.volume = 0;
    }
}
