using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public int damage = 5;
    [SerializeField] Transform playerPosition;
    [SerializeField] float radius;
    public LayerMask zoneAttack;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] attacking = Physics2D.OverlapCircleAll(transform.position, radius, zoneAttack);

        for (int i = 0; i < attacking.Length; i++)
        {
            HidraEnemy hidra = attacking[i].GetComponent<HidraEnemy>();
            if (hidra != null)
            {
                hidra.TakeDamage(damage);
            }
            MushRoomEnemy mush = attacking[i].GetComponent<MushRoomEnemy>();
            if (mush != null)
            {
                mush.TakeDamage(damage);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerPosition.position, radius);
    }
}

