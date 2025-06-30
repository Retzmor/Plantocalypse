using UnityEngine;
using UnityEngine.U2D.IK;

public class tentaculos : MonoBehaviour
{
    private IKManager2D ikManager;

    void Awake()
    {
        ikManager = GetComponent<IKManager2D>();
    }

    void LateUpdate()
    {
        if (ikManager != null)
        {
            ikManager.UpdateManager();
        }
    }
}
