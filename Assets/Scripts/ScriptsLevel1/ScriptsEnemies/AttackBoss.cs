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
    [SerializeField] PlayerLvl1 playerLvl1;
    [SerializeField] float coolDownMelee;
    [SerializeField] float coolDownRange;
    private bool puedeAtacarMelee = true;
    private bool puedeAtacarRange = true;
    private bool estaAtacandoRango = false;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    [SerializeField] GameObject enemy5;
    [SerializeField] GameObject enemy6;
    BossEnemy bossEnemy;
    void Start()
    {
        bossEnemy = GetComponent<BossEnemy>();
    }

    private void Update()
    {
        if (bossEnemy.CurrentHealth == 60)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
        }

        if (bossEnemy.CurrentHealth == 30)
        {
            enemy4.SetActive(true);
            enemy5.SetActive(true);
            enemy6.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Collider2D attackMelee = Physics2D.OverlapCircle(zoneAttackMele.transform.position, radiusMelee, jugador);
        Collider2D attackRange = Physics2D.OverlapCircle(zoneAttackRange.transform.position, radiusRange, jugador);

        if (attackMelee && puedeAtacarMelee)
        {
            if (attackMelee)
            {
                StartCoroutine(StartDamageMele());
            }
        }

        else if (attackRange != null && puedeAtacarRange && !estaAtacandoRango)
        {
            StartCoroutine(StartDamageRange());
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
            if (dentroDelRango)
            {
                playerLvl1.RecibirDaño(damage);
            }
            
        }
    }

    public void EliminarEnemigosInvocados()
    {
        Destroy(enemy1);
        Destroy(enemy2);
        Destroy(enemy3);
        Destroy(enemy4);
        Destroy(enemy5);
        Destroy(enemy6);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(zoneAttackMele.transform.position, radiusMelee);
        Gizmos.DrawWireSphere(zoneAttackRange.transform.position, radiusRange);
        Gizmos.DrawWireSphere(zoneDamageRange.transform.position, damageRange);
    }
}