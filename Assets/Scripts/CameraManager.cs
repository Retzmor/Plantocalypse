using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camJugador;
    [SerializeField] private List<CinemachineVirtualCamera> camEnemigos;
    [SerializeField] private PlayerMovement player;

    public static CameraManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EnfocarCamara(int indice, float duracion)
    {
        if (indice < 0 || indice >= camEnemigos.Count) return;
        StartCoroutine(Transicion(camEnemigos[indice], duracion));
        player.Rb.bodyType = RigidbodyType2D.Static;
    }

    private IEnumerator Transicion(CinemachineVirtualCamera camObjetivo, float duracion)
    {
        BajarPrioridades();
        camObjetivo.Priority = 12;
        player.Rb.bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(duracion + 0.5f);

        BajarPrioridades();
        camJugador.Priority = 12;
        player.Rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void BajarPrioridades()
    {
        camJugador.Priority = 10;
        foreach (var cam in camEnemigos)
        {
            cam.Priority = 10;
        }
    }
}
