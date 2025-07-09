using UnityEngine;
using UnityEngine.UI;

public class BotonesMainMenu : MonoBehaviour
{
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button ButtonSetting;
    [SerializeField] private Button ButtonExit;
    [SerializeField] private Button ButtonCredits;
    [SerializeField] private Button ButtonOptionsExit;
    [SerializeField] private Button ButtonCreditsExit;

    private void Start()
    {
        ButtonPlay.onClick.AddListener(GameAdministrator.Instance.MainMenuPrincipal);
        ButtonSetting.onClick.AddListener(GameAdministrator.Instance.Options);
        ButtonExit.onClick.AddListener(GameAdministrator.Instance.GameClose);
        ButtonCredits.onClick.AddListener(GameAdministrator.Instance.Credits);
        ButtonOptionsExit.onClick.AddListener(GameAdministrator.Instance.MainMenu);
        ButtonCreditsExit.onClick.AddListener(GameAdministrator.Instance.MainMenu);
    }
}
