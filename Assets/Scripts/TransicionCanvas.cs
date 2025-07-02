using System.Collections;
using UnityEngine;

public class TransicionCanvas : MonoBehaviour
{
    Animator anim;
    [SerializeField] AnimationClip animacionFinal;
    [SerializeField] GameObject canvas;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        StartCoroutine(CambiarDeEscena());
    }

    IEnumerator CambiarDeEscena()
    {
        anim.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        Destroy(canvas);
    }
}
