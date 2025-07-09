using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    public void MenuPausa()
    {
        GameAdministrator.Instance.Pausa();
    }

    public void Despausar()
    {
        GameAdministrator.Instance.Despausar();
    }

    public void Reiniciar(string name) 
    {
        GameAdministrator.Instance.GameStart(name);
    }

    public void MenuInicial(string name)
    {
        GameAdministrator.Instance.StageChange(name);
    }

    public void SiguienteNivel()
    {
        GameAdministrator.Instance.GameContinue();
    }
}


