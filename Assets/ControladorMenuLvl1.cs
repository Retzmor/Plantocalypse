using UnityEngine;

public class ControladorMenuLvl1 : MonoBehaviour
{
    public void Pausa()
    {
        GameAdministrator.Instance.Pausa();
    }

    public void Despausar()
    {
        GameAdministrator.Instance.Despausar();
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
