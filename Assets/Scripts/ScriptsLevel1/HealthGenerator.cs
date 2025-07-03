using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> curas = new List<GameObject>();

    private GameObject curaActual;
    private bool esperandoNuevaCura = false;

    void Start()
    {
        ActivarNuevaCura();
    }

    void Update()
    {
        if (curaActual != null && !curaActual.activeSelf && !esperandoNuevaCura)
        {
            esperandoNuevaCura = true;
        }
    }

    void ActivarNuevaCura()
    {
        List<GameObject> disponibles = new List<GameObject>();

        for (int i = 0; i < curas.Count; i++)
        {
            if (!curas[i].activeSelf)
            {
                disponibles.Add(curas[i]);
            }
        }

        if (disponibles.Count == 0)
        {
            Destroy(gameObject);
        }

        int indice = Random.Range(0, disponibles.Count);
        GameObject nuevaCura = disponibles[indice];

        nuevaCura.SetActive(true);
        curaActual = nuevaCura;
        esperandoNuevaCura = false;
    }
}
