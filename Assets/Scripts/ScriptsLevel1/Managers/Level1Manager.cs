using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    [SerializeField] private DialoguesManager dialoguesManager;
    [SerializeField] private CamerasManagers camerasManager;
    [SerializeField] private GameObject randomGeneration;
    [SerializeField] private GameObject player;

    void Start()
    {
        dialoguesManager.OnDialoguesFinished += EmpezarJuego;
        InicioDeNivel();
    }

    public void InicioDeNivel()
    {
        string[] dialoguesCurrent =
        {
            "Bienvenido.",
            "Es hora de que enfrentes a las plantas mutantes.",
            "Debes resistir 5 minutos luchando.",
            "En el mapa aparecerán monedas aleatorias.",
            "Tómalas, te aumentarán la vida.",
            "¡Buena suerte!"
        };

        dialoguesManager.StartDialogues(dialoguesCurrent);
    }

    void EmpezarJuego()
    {
        camerasManager.VolverACamaraJugador();
        camerasManager.ZoomOutInicio(10f);
        dialoguesManager.SkipButton.gameObject.SetActive(false);
       randomGeneration.SetActive(true);
    }
    
}
