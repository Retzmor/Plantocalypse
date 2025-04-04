using UnityEngine; //Importante
using UnityEngine.UI; //Habilita implementar el Slider
public class VolumeControl : MonoBehaviour
{

    Slider control;

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
