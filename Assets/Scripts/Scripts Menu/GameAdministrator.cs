using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAdministrator : MonoBehaviour
{

    public static GameAdministrator instance;
    public delegate void LegacyGameState();
    public LegacyGameState optionsMenu;
    public LegacyGameState creditsMenu;
    public LegacyGameState mainMenu;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

    public void GameClose()
    {
        Application.Quit();
    }
}
