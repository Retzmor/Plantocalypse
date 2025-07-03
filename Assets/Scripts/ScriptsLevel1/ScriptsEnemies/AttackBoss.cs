using System.Collections;
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
    [SerializeField] float coolDownMelee;
    [SerializeField] float coolDownRange;
    private bool puedeAtacarMelee = true;
    private bool puedeAtacarRange = true;
    private bool estaAtacandoRango = false;


    BossEnemy bossEnemy;
    void Start()
    {
        bossEnemy = GetComponent<BossEnemy>();
    }

    private void FixedUpdate()
    {
        Collider2D attackMelee = Physics2D.OverlapCircle(zoneAttackMele.transform.position, radiusMelee, jugador);
        Collider2D attackRange = Physics2D.OverlapCircle(zoneAttackRange.transform.position, radiusRange, jugador);

        if (attackMelee && puedeAtacarMelee)
        {
            if(attackMelee)
            {
                StartCoroutine(StartDamageMele());
            }
        }

        else if (attackRange != null && puedeAtacarRange && !estaAtacandoRango)
        {
                StartCoroutine(StartDamageRange());
        }

        else 
        {
            hacerDaño=false;
        }
    }

    IEnumerator StartDamageMele()
    {
        puedeAtacarMelee = false;
        bossEnemy.AnimatorBoss.SetTrigger("AttackMelee");
        yield return new WaitForSeconds(coolDownMelee);
        puedeAtacarMelee = true;
    }
    IEnumerator StartDamageRange()
    {
        estaAtacandoRango = true;
        puedeAtacarRange = false;
        bossEnemy.AnimatorBoss.SetTrigger("AttackRange");
        yield return new WaitForSeconds(coolDownRange);
        puedeAtacarRange = true;
        estaAtacandoRango = false;
    }

    public void DamageMelee()
    {
            playerLvl1.RecibirDaño(damage);
    }

    public void DamageRange()
    {
        bool dentroDelRango = Physics2D.OverlapCircle(zoneDamageRange.transform.position, damageRange, jugador);
        {
            playerLvl1.RecibirDaño(damage);
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
