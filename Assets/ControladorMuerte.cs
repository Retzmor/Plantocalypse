using UnityEngine;

public class ControladorMuerte : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.MusicStop();
    }
    public void Reiniciar(string name)
    {
        GameAdministrator.Instance.StageChange(name);
    }

    public void MenuPrincipal(string name)
    {
        GameAdministrator.Instance.GameStart(name);
    }
}
