using UnityEngine;

public class ControladorMuerteTutorial : MonoBehaviour
{
    public void Reiniciar(string name)
    {
        GameAdministrator.Instance.StageChange(name);
    }

    public void MenuPrincipal(string name)
    {
        GameAdministrator.Instance.GameStart(name);
    }
}
