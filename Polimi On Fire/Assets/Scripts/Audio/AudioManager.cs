using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    int counter = 0;
    
    public AudioSource BackgroundMusic;

    public AudioSource SoundEffects;

    public AudioClip[] BackgroundMusicClips;

    public AudioClip[] CoinSound;

    public AudioClip[] CrashSound;
    // Start is called before the first frame update    
    void Start()
    {
        BackgroundMusic.clip = BackgroundMusicClips[0];
        BackgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((FindObjectOfType<PlayerMove>().isDead) && (counter == 0))
        {
            BackgroundMusic.Stop();
            SoundEffects.clip = CrashSound[0];
            SoundEffects.Play();
            counter += 1;
        }
    }

    public void Coins()
    {
        SoundEffects.clip = CoinSound[0];
        SoundEffects.Play();
    }
}
