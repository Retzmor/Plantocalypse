using TMPro;
using UnityEngine;

public class TiempoController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI contadorTexto;
    private float contadorActual = 60;
    public bool empezarTiempo = false;
    public delegate void AcaboElTiempo();
    public AcaboElTiempo seAcaboElTiempo;
    public bool frenarCuenta = false;
  
    void Update()
    {
        if (empezarTiempo == true)
        {
            ContadorTiempo();
        }

        if(contadorActual == 0 && frenarCuenta == false)
        {
            frenarCuenta = true;
            seAcaboElTiempo?.Invoke();
        } 
    }

    public void ContadorTiempo()
    {
        contadorActual -= Time.deltaTime;
        contadorActual = Mathf.Max(0, contadorActual);
        ActualizarControlador();
    }

    public void ActualizarControlador()
    {
        contadorTexto.text = Mathf.CeilToInt(contadorActual).ToString();
    }
}
