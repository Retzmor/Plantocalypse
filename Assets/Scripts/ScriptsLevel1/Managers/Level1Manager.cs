using JetBrains.Annotations;
using UnityEngine;
using System.Collections;


public class Level1Manager : MonoBehaviour
{
    [SerializeField] private DialoguesManager dialoguesManager;
    [SerializeField] private CamerasManagers camerasManager;
    [SerializeField] private GameObject randomGeneration;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerLvl1 playerLvl1;
    [SerializeField] private TiempoController tiempoController;
    [SerializeField] private RandomGeneration Random;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject collider1;
    [SerializeField] private GameObject collider2;
    [SerializeField] private GameObject collider3;
    [SerializeField] private GameObject collider4;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject barraVida;
    [SerializeField] AudioClip musica1;
    [SerializeField]  AudioClip musica2;

    public Transform posicionFinal;
    public Cinemachine.CinemachineVirtualCamera camara;

    void Start()
    {
        dialoguesManager.OnDialoguesFinished += EmpezarJuego;
        tiempoController.seAcaboElTiempo += JefeFinal;
        InicioDeNivel();
        AudioManager.Instance.PlayMusic(musica1);

    }

    public void InicioDeNivel()
    {
        string[] dialoguesCurrent =
        {
            "Bienvenido.",
            "Es hora de que enfrentes a las plantas mutantes.",
            "Debes resistir 90 segundos luchando.",
            "En el mapa aparecerán corazones aleatorios.",
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
        tiempoController.empezarTiempo = true;
    }

    public void JefeFinal()
    {
        Panel.SetActive(true);
        player.transform.position = posicionFinal.position;
        camara.OnTargetObjectWarped(player.transform, posicionFinal.position - player.transform.position);
        camara.Follow = null;
        camara.transform.position = new Vector3(posicionFinal.position.x, posicionFinal.position.y, camara.transform.position.z);
        camara.m_Lens.OrthographicSize = 10f;
        Random.DetenerGeneracion();
        Random.LiberarTodosLosEnemigos();
        randomGeneration.SetActive(false);
        boss.SetActive(true);
        collider1.SetActive(true);
        collider2.SetActive(true);
        collider3.SetActive(true);
        collider4.SetActive(true);
        StartCoroutine(ActivarPanel());
        playerLvl1.CurarActivar();
        barraVida.SetActive(true);
        AudioManager.Instance.PlayMusic(musica2);
        float vida = playerLvl1.currenHealthPlayer = 120;
        playerLvl1.BarraVida.InicializarBarraVida(vida);
    }

    IEnumerator ActivarPanel()
    {
        yield return new WaitForSeconds(5); 
        Panel.SetActive(false);
    }
}
