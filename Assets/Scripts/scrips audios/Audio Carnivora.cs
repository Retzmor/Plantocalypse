using System;
using UnityEngine;

public class AudioCarnivora : MonoBehaviour
{
    [SerializeField] AudioClip sonido;


    public void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.CompareTag("Player"))
        {
           //ControladorAudios.Intance.EjecutarSonido(sonido);
        }
    }
}
