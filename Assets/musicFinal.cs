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

        // Reproducir la música una vez que el AudioManager esté listo
        AudioManager.Instance.PlayMusic(musicClip);
    }
}

