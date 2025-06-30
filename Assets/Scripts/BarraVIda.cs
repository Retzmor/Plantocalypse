using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVIda : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarvidaMaxima(float VidaMaxima)
    {
        slider.maxValue = VidaMaxima; 
    }

    public void CambiarVidaActual(float CantidadVida)
    {
        slider.value = CantidadVida;
    }

    public void InicializarBarraVida(float CantidadVida)
    {
        CambiarvidaMaxima(CantidadVida);
        CambiarVidaActual(CantidadVida);
    }


}  

