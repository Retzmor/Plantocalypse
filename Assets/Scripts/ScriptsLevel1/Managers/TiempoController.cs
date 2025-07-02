using TMPro;
using UnityEngine;

public class TiempoController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI contadorTexto;
    private float contadorActual = 300;
    public bool empezarTiempo = false;
    public delegate void AcaboElTiempo();
    public AcaboElTiempo seAcaboElTiempo;
  
    void Update()
    {
        if (empezarTiempo == true)
        {
            ContadorTiempo();
        }

        if(contadorActual <= 0)
        {
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
