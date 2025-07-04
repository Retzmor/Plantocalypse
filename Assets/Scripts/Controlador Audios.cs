using UnityEngine;

public class ControladorAudios : MonoBehaviour
{
    public static  ControladorAudios Intance;
    public AudioSource pasosSource;
    private AudioSource audioSource;

    private void Awake()
    {
        if(Intance == null)
        {
            Intance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }


    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }

    public void EjecutarAudioUnaVez(AudioClip sonido2)
    {
        audioSource.PlayOneShot(sonido2);

    }

    public void ReproducirPasos(AudioClip clip)
    {
        if (!pasosSource.isPlaying)
        {
            pasosSource.clip = clip;
            pasosSource.loop = true;
            pasosSource.Play();
        }
    }

    public void DetenerPasos()
    {
        if (pasosSource.isPlaying)
        {
            pasosSource.Stop();
        }
    }

}


