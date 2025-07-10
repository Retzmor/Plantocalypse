using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textoIntro;

    [SerializeField]
    string[] lineasDeTexto = new string[]
    {
        "En los campos enfermos, la vida susurra con voz quebrada.",
        "Donde antes brotaba el verde, ahora solo queda ceniza.",
        "El virus, sin rostro, sin piedad, marchitó la esperanza.",
        "Y los sabios, altivos, no supieron escuchar los lamentos del suelo.",
        "Pero tú, humilde sembrador de mañanas, oíste el llamado.",
        "Tus manos, curtidas por la tierra, acarician la cura.",
        "A cada raíz, a cada hoja, prometiste redención.",
        "Y aunque el tiempo es breve, tu decisión es firme.",
        "Salvarás lo que queda... o perecerás con ello.",
        "- *Elegía de la Tierra Marchita*, autor anónimo."
    };

    [SerializeField] float tiempoAutoAvance = 4f; 
    private float tiempoEspera = 0f;

    private int lineaActual = 0;
    private bool puedePasarLinea = true;

    void Start()
    {
        textoIntro.text = lineasDeTexto[lineaActual];
    }

    void Update()
    {
        
        tiempoEspera += Time.deltaTime;

        
        if ((Input.GetKeyDown(KeyCode.Space) || tiempoEspera >= tiempoAutoAvance) && puedePasarLinea)
        {
            tiempoEspera = 0f; 
            lineaActual++;

            if (lineaActual < lineasDeTexto.Length)
            {
                textoIntro.text += "\n" + lineasDeTexto[lineaActual]; 
            }
            else
            {
                puedePasarLinea = false;
                Invoke("CambiarEscena", 1.5f); 
            }
        }
    }

    public void CambiarEscena(string name)
    {
        GameAdministrator.Instance.GameStart(name);    
    }
}
