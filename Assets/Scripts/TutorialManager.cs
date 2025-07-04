using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject panelFelicidades;
    [SerializeField] private ScriptDialogue dialogueManager;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private GameObject enemigo1;
    [SerializeField] private GameObject enemigo2;
    [SerializeField] private GameObject enemigo3;
    [SerializeField] AudioClip musicaTutorial;

    public delegate void PlayerMovementDelegate(bool activarRb);
    public static event PlayerMovementDelegate playerMovementDelegate;

    private int enemigosDerrotados = 0;

    void Start()
    {
        IniciarTutorial();
        AudioManager.Instance.PlayMusic(musicaTutorial);
    }

    public void IniciarTutorial()
    {
        string[] dialogoInicial = {
            "¡Bienvenido al tutorial!",                                     //Alejandr@s, si van a añadir algo al texto, hacerlo en esas comillas, este es el primer cuadro que se muestras
            "Derrota al primer enemigo."
        };
        
        dialogueManager.SetDialogue(dialogoInicial);
        dialogueManager.OnDialogueEnd = () =>
        {
            cameraManager.EnfocarCamara(0, 3f); 
            StartCoroutine(ActivarConRetraso(enemigo1, 3f));
            playerMovementDelegate?.Invoke(true);
        };
    }

    public void EnemigoDerrotado()
    {
        enemigosDerrotados++;
        Debug.Log("Enemigos derrotados: " + enemigosDerrotados);

        if (enemigosDerrotados == 1)
        {
            string[] dialogo = {
                "¡Muy bien!",
                "Ahora enfréntate a los siguientes dos enemigos."                              //este es el segundo texto
            };

            dialogueManager.SetDialogue(dialogo);
            dialogueManager.OnDialogueEnd = () =>
            {
                StartCoroutine(EnfocarYActivarSiguientesEnemigos());
            };
        }

        if (enemigosDerrotados == 3)
        {
    
            string[] final = {
                "¡Has completado el tutorial!",                                 //este es el ultimo
                "Estás listo para la batalla."
            };

            dialogueManager.SetDialogue(final);

            dialogueManager.OnDialogueEnd = () =>
            {
                panelFelicidades.gameObject.SetActive(true);
            };
        }
    }

    private IEnumerator ActivarConRetraso(GameObject enemigo, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        enemigo.SetActive(true);
    }

    private IEnumerator EnfocarYActivarSiguientesEnemigos()
    {
        cameraManager.EnfocarCamara(1, 2.5f); 
        yield return new WaitForSeconds(3f);
        enemigo2.SetActive(true);

        cameraManager.EnfocarCamara(2, 2.5f); 
        yield return new WaitForSeconds(3f);
        enemigo3.SetActive(true);
    }
}
