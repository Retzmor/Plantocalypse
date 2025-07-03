using UnityEngine;

public class AttackBoss : MonoBehaviour
{
    
    [SerializeField] GameObject zoneAttackMele;
    [SerializeField] GameObject zoneAttackRange;
    [SerializeField] int damage;
    [SerializeField] float radiusMelee;
    [SerializeField] float radiusRange;
    [SerializeField] float damageRange;
    [SerializeField] LayerMask jugador;
    [SerializeField] GameObject zoneDamageRange;
    [SerializeField] bool hacerDaño = false;
    [SerializeField] PlayerLvl1 playerLvl1;
    [SerializeField] float coolDown;
    private float coolDownAttack = -Mathf.Infinity;

    BossEnemy bossEnemy;
    void Start()
    {
        bossEnemy = GetComponent<BossEnemy>();
    }

    private void FixedUpdate()
    {
        Collider2D attackMelee = Physics2D.OverlapCircle(zoneAttackMele.transform.position, radiusMelee, jugador);
        Collider2D attackRange = Physics2D.OverlapCircle(zoneAttackRange.transform.position, radiusRange, jugador);

        if (attackMelee)
        {
            bossEnemy.AnimatorBoss.SetTrigger("AttackMelee");
            if(attackMelee)
            {
                playerLvl1.RecibirDaño(damage);
            }
        }

        else if (attackRange)
        {
            bossEnemy.AnimatorBoss.SetTrigger("AttackRange");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hacerDaño = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(zoneAttackMele.transform.position, radiusMelee);
        Gizmos.DrawWireSphere(zoneAttackRange.transform.position, radiusRange);
        Gizmos.DrawWireSphere(zoneDamageRange.transform.position, damageRange);
    }
}
