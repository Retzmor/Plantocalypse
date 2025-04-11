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
    private string currentStage = "ScenaTutorial";
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
        }
    }
    private void Start()
    {
        Time.timeScale = 0;
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
    }

    public void GameContinue()
    {
        SceneManager.LoadScene(currentStage);
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
