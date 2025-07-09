using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVIda : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Awake()
    {
        if (slider == null)
            slider = GetComponent<Slider>();
    }

    public void CambiarvidaMaxima(float VidaMaxima)
    {
        if (slider != null)
            slider.maxValue = VidaMaxima;
    }

    public void CambiarVidaActual(float CantidadVida)
    {
        if (slider != null)
            slider.value = CantidadVida;
    }

    public void InicializarBarraVida(float CantidadVida)
    {
        CambiarvidaMaxima(CantidadVida);
        CambiarVidaActual(CantidadVida);
    }
}  

