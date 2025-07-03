using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> curas = new List<GameObject>();

    private GameObject curaActual;

    void Start()
    {
        ActivarCuraAleatoria();
    }

    void Update()
    {
        // Si la cura actual fue recogida (ya no está activa)
        if (curaActual != null && !curaActual.activeSelf)
        {
            ActivarCuraAleatoria();
        }
    }

    void ActivarCuraAleatoria()
    {
        // Buscar todas las curas que están desactivadas
        List<GameObject> disponibles = new List<GameObject>();
        for (int i = 0; i < curas.Count; i++)
        {
            if (!curas[i].activeSelf)
            {
                disponibles.Add(curas[i]);
            }
        }

        // Si no hay disponibles, salir
        if (disponibles.Count == 0)
        {
            Destroy(gameObject);
        }

        // Elegir una aleatoria
        int indice = Random.Range(0, disponibles.Count);
        curaActual = disponibles[indice];

        // Activar la nueva cura
        curaActual.SetActive(true);
    }
}
