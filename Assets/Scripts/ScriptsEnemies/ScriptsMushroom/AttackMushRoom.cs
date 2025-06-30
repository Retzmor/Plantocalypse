using UnityEngine;

public class AttackMushRoom : MonoBehaviour
{
    MushRoomEnemy m_Enemy;
    [SerializeField] PlayerMovement p_Movement;
    [SerializeField] float radiusAttack;
    [SerializeField] GameObject zoneAttack;
    [SerializeField] int damage;
    [SerializeField] float coolDown;
    private float coolDownAttack = -Mathf.Infinity;

    void Start()
    {
       m_Enemy = GetComponent<MushRoomEnemy>();
    }

    private void FixedUpdate()
    {
        Collider2D attack = Physics2D.OverlapCircle(zoneAttack.transform.position, radiusAttack, m_Enemy.LayermaskMushRoom);
        if (attack && Time.time - coolDownAttack >= coolDown)
        {
            ToAttack();
            coolDownAttack = Time.time;
        }
    }

    public void ToAttack()
    {
        m_Enemy.AnimatorMushroom.SetTrigger("Attack");
        p_Movement.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(zoneAttack.transform.position,radiusAttack);
    }
}
