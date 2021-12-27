

using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BackgroundMusic;

    public AudioSource AlarmSounds;
    
    public AudioSource SoundEffects;
    
    public AudioSource Fire;

    public AudioClip[] BackgroundMusicClips;

    public AudioClip[] CoinSound;

    public AudioClip[] CrashSound;
    
    public AudioClip[] StartSound;
    
    public AudioClip[] FireDeathSound;
    
    public AudioClip[] ButtonSound;
    
    public AudioClip[] HoverSound;

    public AudioClip[] VolumeSound;
    
    public AudioClip[] FireSounds;

    public AudioClip[] AlarmSound;
    
    
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
    
    public void FireSound()
    {
        SoundEffects.clip = FireSounds[0];
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
        AlarmSounds.Stop();
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
    
    public void StartBuilding()
    {
        BackgroundMusic.clip = BackgroundMusicClips[2];
        BackgroundMusic.Play();
        
    }
    public void ButtonPress()
    {
        SoundEffects.clip = ButtonSound[0];
        SoundEffects.Play();
    }
    
    public void ButtonHover()
    {
        SoundEffects.clip = HoverSound[0];
        SoundEffects.Play();
    }
    
    public void VolumeCheck()
    {
        SoundEffects.clip = VolumeSound[0];
        SoundEffects.Play();
    }

    public void StartAlarm()
    {
        AlarmSounds.clip = AlarmSound[0];
        AlarmSounds.Play();
    }
}

