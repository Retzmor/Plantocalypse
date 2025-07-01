using System;
using UnityEngine;

public class AudioHidra : MonoBehaviour
{
    private AudioSource audiosource;



    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Console.WriteLine("collisiono");

        if (collision.CompareTag("Player"))
        {
            audiosource.PlayOneShot(audiosource.clip);
        }
    }
}
