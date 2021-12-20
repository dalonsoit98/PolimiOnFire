using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class VolumeMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider VolumeSlider;
    private float volume;

    private void Start()
    {
       audioMixer.GetFloat("volume",out volume);
       VolumeSlider.value = volume;
       FindObjectOfType<AudioManager>().VolumeCheck();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void ToOptionsScene()
    {
        FindObjectOfType<AudioManager>().ButtonPress();
        SceneManager.LoadScene("Options");
    }
    
}
