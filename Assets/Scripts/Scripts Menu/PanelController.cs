using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public static PanelController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] GameObject mainMenuPanel, optionsPanel, creditsPanel, gameOverPanel, gameMenuPausa, gameInterfazMenu;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameAdministrator.Instance.mainMenu += ShowMainPanel;
        GameAdministrator.Instance.optionsMenu += ShowOptionsPanel;
        GameAdministrator.Instance.creditsMenu += ShowCreditsPanel;
        GameAdministrator.Instance.gameOverMenu += ShowGameOverPanel;
        GameAdministrator.Instance.menuPausa += ShowMenuPausa;
        GameAdministrator.Instance.menuDespausa += DesactiveMenuPausa;
    }

    private void OnDisable()
    {
        GameAdministrator.Instance.mainMenu -= ShowMainPanel;
        GameAdministrator.Instance.optionsMenu -= ShowOptionsPanel;
        GameAdministrator.Instance.creditsMenu -= ShowCreditsPanel;
        GameAdministrator.Instance.gameOverMenu -= ShowGameOverPanel;
        GameAdministrator.Instance.menuPausa -= ShowMenuPausa;
        GameAdministrator.Instance.menuDespausa -= DesactiveMenuPausa;
    }

    public void ShowMainPanel()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowOptionsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void ShowMenuPausa()
    {
        gameMenuPausa.SetActive(true);
    }

    public void DesactiveMenuPausa()
    {
        gameMenuPausa.SetActive(false);
    }
}
