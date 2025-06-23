using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textoIntro;
    [SerializeField] float tiempoDeAparacionLineas = 2f;

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

    private int lineaActual = 0;

    void Start()
    {
        textoIntro.text = ""; // Asegura que empiece vac�o
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        while (lineaActual < lineasDeTexto.Length)
        {
            textoIntro.text += lineasDeTexto[lineaActual] + "\n";

            yield return new WaitForSeconds(tiempoDeAparacionLineas);
            lineaActual++;
        }

        // Espera un poco antes de cambiar de escena
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("ScenaTutorial");
    }
}