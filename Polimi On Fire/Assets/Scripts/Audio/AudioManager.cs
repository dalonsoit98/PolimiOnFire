

using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BackgroundMusic;

    public AudioSource SoundEffects;

    public AudioClip[] BackgroundMusicClips;

    public AudioClip[] CoinSound;

    public AudioClip[] CrashSound;
    
    public AudioClip[] StartSound;
    
    public AudioClip[] FireDeathSound;
    
    
    // Start is called before the first frame update    
   void Start()
    {
        /*BackgroundMusic.clip = BackgroundMusicClips[0];
        BackgroundMusic.Play();*/
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Coins()
    {
        SoundEffects.clip = CoinSound[0];
        SoundEffects.Play();
    }
    
    public void Death()
    {
        SoundEffects.clip = CrashSound[0];
        SoundEffects.Play();
    }
    
    public void FireDeath()
    {
        SoundEffects.clip = FireDeathSound[0];
        SoundEffects.Play();
    }

    public void MusicStop()
    {
        BackgroundMusic.Stop();
    }

    public void StartCountdown()
    {
        SoundEffects.clip = StartSound[0];
        SoundEffects.Play();
    }

    public void StartEndless()
    {
        BackgroundMusic.clip = BackgroundMusicClips[0];
        BackgroundMusic.Play();
    }
}

