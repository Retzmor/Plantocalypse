using UnityEngine;

public class ControladorAudios : MonoBehaviour
{
    public static  ControladorAudios Intance;

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
}
