using UnityEngine;

public class AttackMushRoom : MonoBehaviour
{
    MushRoomEnemy m_Enemy;
    [SerializeField] PlayerMovement p_Movement;
    [SerializeField] float radiusAttack;
    [SerializeField] GameObject zoneAttack;
    [SerializeField] int damage;
     void Start()
    {
       m_Enemy = GetComponent<MushRoomEnemy>();
    }

    private void FixedUpdate()
    {
        Collider2D attack = Physics2D.OverlapCircle(zoneAttack.transform.position,radiusAttack,m_Enemy.LayermaskMushRoom);
        if (attack)
        {
            m_Enemy.AnimatorMushroom.SetTrigger("Attack");
            ToAttack();
        }
    }

    public void ToAttack()
    {
        p_Movement.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(zoneAttack.transform.position,radiusAttack);
    }
}
