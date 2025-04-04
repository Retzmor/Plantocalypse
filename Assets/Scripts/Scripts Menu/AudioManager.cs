using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource soundEffects;
    [SerializeField] AudioSource music;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySFX(AudioClip sound)
    {
        soundEffects.PlayOneShot(sound);
    }

    public void PlayMusic(AudioClip musicSong)
    {
        music.Stop();
        music.clip = musicSong;
        music.Play();
        music.loop = true;
    }

    public void MusicVolume(float newVolume)
    {
        music.volume = newVolume;
    }

    public void SFXVolume(float newVolume)
    {
        soundEffects.volume = newVolume;
    }
}
