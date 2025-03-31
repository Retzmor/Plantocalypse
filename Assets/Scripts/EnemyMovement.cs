using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] int velocityEnemy = 4;
    [SerializeField] bool ubication;
    [SerializeField] bool activation = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {


        if (rigid.position.x > 1 && ubication == false)
        {
            
            rigid.velocity = new Vector2(-velocityEnemy, 0);
            if (rigid.position.x <= 2)
            {
                Debug.Log("Ubicacion verdader");
                ubication = true;

            }
        }

        else if (ubication == true)
        {
            Debug.Log("Me estoy moviendo a la derecha");
            rigid.velocity = new Vector2(velocityEnemy, 0);
            if (rigid.position.x >= 13)
            {
                Debug.Log("Ubicacion falsa");
                ubication = false;

            }
        }
    }

}
