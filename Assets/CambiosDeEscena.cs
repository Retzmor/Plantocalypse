using UnityEngine;

public class CambiosDeEscena : MonoBehaviour
{
   public void SalirDeJuego()
    {
        GameAdministrator.Instance.GameClose();
    }

    public void EmpezarJuego()
    {
        GameAdministrator.Instance.GameStart("MenuPrincipal");
        Debug.Log("hola");    
            }
}
