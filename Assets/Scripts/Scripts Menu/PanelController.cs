using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    [SerializeField] GameObject mainMenuPanel, optionsPanel, creditsPanel;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameAdministrator.Instance.mainMenu += ShowMainPanel;
        GameAdministrator.Instance.optionsMenu += ShowOptionsPanel;
        GameAdministrator.Instance.creditsMenu += ShowCreditsPanel;
    }

    private void OnDisable()
    {
        GameAdministrator.Instance.mainMenu -= ShowMainPanel;
        GameAdministrator.Instance.optionsMenu -= ShowOptionsPanel;
        GameAdministrator.Instance.creditsMenu -= ShowCreditsPanel;
    }

    public void ShowMainPanel()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowOptionsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
