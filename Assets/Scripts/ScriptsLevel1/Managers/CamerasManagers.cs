using Cinemachine;
using UnityEngine;

public class CamerasManagers : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camPlayer;
    [SerializeField] private CinemachineVirtualCamera camCoin;

    public void FocusOnStart()
    {
        camPlayer.Priority = 10;
        camCoin.Priority = 20;
    }

    public void VolverACamaraJugador()
    {
        camCoin.Priority = 10;
        camPlayer.Priority = 20;
    }

    public void ZoomOutInicio(float nuevoZoom)
    {
        camPlayer.m_Lens.OrthographicSize = nuevoZoom;
    }
}
