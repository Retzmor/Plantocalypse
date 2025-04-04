using UnityEngine; //Importante
using UnityEngine.UI; //Habilita implementar el Slider
using UnityEngine.EventSystems; //Habilita la funcion OnPointerUp

public class VolumeControl : MonoBehaviour, IPointerUpHandler
{

    Slider control;
    public AudioClip sfxTest;

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX(sfxTest);
    }
    void Start()
    {
        control = GetComponent<Slider>();
    }

    public void ChangeMusicVolume()
    {
        AudioManager.Instance.MusicVolume(control.value);
    }

    public void ChangeSFXVolume()
    {
        AudioManager.Instance.SFXVolume(control.value);
    }
}
