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
        "El virus, sin rostro, sin piedad, marchitó la esperanza.",
        "Y los sabios, altivos, no supieron escuchar los lamentos del suelo.",
        "Pero tú, humilde sembrador de mañanas, oíste el llamado.",
        "Tus manos, curtidas por la tierra, acarician la cura.",
        "A cada raíz, a cada hoja, prometiste redención.",
        "Y aunque el tiempo es breve, tu decisión es firme.",
        "Salvarás lo que queda... o perecerás con ello.",
        "- *Elegía de la Tierra Marchita*, autor anónimo."
    };

    private int lineaActual = 0;

    void Start()
    {
        textoIntro.text = ""; // Asegura que empiece vacío
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