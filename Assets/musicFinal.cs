using System.Collections;
using UnityEngine;

public class musicFinal : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    IEnumerator Start()
    {
        // Esperar hasta que AudioManager.Instance no sea null
        while (AudioManager.Instance == null)
            yield return null;

        // Reproducir la m�sica una vez que el AudioManager est� listo
        AudioManager.Instance.PlayMusic(musicClip);
    }
}

