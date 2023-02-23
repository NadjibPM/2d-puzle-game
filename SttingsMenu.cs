using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SttingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Awake() 
    {
        PlayerPrefs.GetFloat("volume");
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
