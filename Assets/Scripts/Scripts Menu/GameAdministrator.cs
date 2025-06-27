using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdministrator : MonoBehaviour
{

    public static GameAdministrator Instance;
    public delegate void LegacyGameState();
    public LegacyGameState optionsMenu;
    public LegacyGameState creditsMenu;
    public LegacyGameState mainMenu;
    public LegacyGameState gameOverMenu;
    public LegacyGameState menuPausa;
    public LegacyGameState menuDespausa;
    private string currentStage = "Intro";


    [SerializeField] private ScriptDialogue scriptDialogue;
    [SerializeField] private CameraManager cameraManager;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    private void Start()
    {
        
    }

    public void MainMenu()
    {
        Time.timeScale = 0;
        mainMenu?.Invoke();
    }

    public void GameStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
        currentStage = sceneName;
        Debug.Log("Escenario: " + currentStage);
        
    }

    public void StageChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        currentStage = sceneName;
        Time.timeScale = 1;
        menuDespausa?.Invoke();
    }

    public void GameContinue()
    {
        SceneManager.LoadScene("Nivel1");
        Time.timeScale = 1;
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Options()
    {
        Time.timeScale = 0;
        optionsMenu?.Invoke();
    }

    public void Pausa()
    {
        Time.timeScale = 0;
        menuPausa?.Invoke();
    }

    public void Despausar()
    {
        Time.timeScale = 1;
        menuDespausa?.Invoke();
    }

    public void Credits()
    {
        Time.timeScale = 0;
        creditsMenu?.Invoke();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu?.Invoke();
    }

    public void GameClose()
    {
        Application.Quit();
    }
}
