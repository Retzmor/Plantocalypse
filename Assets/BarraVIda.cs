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

    public void CambiarVidaActual(float CantidadVida)
    {
        slider.value = CantidadVida;

    }
}

