using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI textoIntro;
    [SerializeField] float tiempoDeAparacionLetras;
    [SerializeField] string[] lineasDeTexto;
    private int lineaActual = 0;
    void Start()
    {
        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
        while (lineaActual < lineasDeTexto.Length)
        {
            textoIntro.text = "";
            string linea = lineasDeTexto[lineaActual];

            foreach (char letra in linea.ToCharArray())
            {
                textoIntro.text += letra;
                yield return new WaitForSeconds(tiempoDeAparacionLetras);
            }

            yield return new WaitForSeconds(2f);
            lineaActual++;
        }

        SceneManager.LoadScene("ScenaTutorial");

    }
}
