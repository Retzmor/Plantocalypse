using System;
using UnityEngine;

public class AudioHidra : MonoBehaviour
{
    [SerializeField] AudioClip sonido;

   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Console.WriteLine("collisiono");

        if (collision.CompareTag("Player"))
        {
           ControladorAudios.Intance.EjecutarSonido(sonido);
        }
    }
}
