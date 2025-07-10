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
        "El virus, sin rostro, sin piedad, marchit� la esperanza.",
        "Y los sabios, altivos, no supieron escuchar los lamentos del suelo.",
        "Pero t�, humilde sembrador de ma�anas, o�ste el llamado.",
        "Tus manos, curtidas por la tierra, acarician la cura.",
        "A cada ra�z, a cada hoja, prometiste redenci�n.",
        "Y aunque el tiempo es breve, tu decisi�n es firme.",
        "Salvar�s lo que queda... o perecer�s con ello.",
        "- *Eleg�a de la Tierra Marchita*, autor an�nimo."
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
