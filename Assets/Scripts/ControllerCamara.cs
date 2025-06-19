using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class ControllerCamara : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera CamPlayer;
    [SerializeField] CinemachineVirtualCamera CamEnemy;
    public void FocusEnemyThenReturn()
    {
        StartCoroutine(FocusRoutine());
    }

    private IEnumerator FocusRoutine()
    {
        CamPlayer.Priority = 10;
        CamEnemy.Priority = 12;

        yield return new WaitForSeconds(4f);
        CamPlayer.Priority = 12;
        CamEnemy.Priority = 10;
    }

}
