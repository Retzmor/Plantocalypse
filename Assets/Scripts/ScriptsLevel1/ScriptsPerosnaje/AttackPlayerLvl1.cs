using UnityEngine;

public class AttackPlayerLvl1 : MonoBehaviour
{
    public int damage = 5;
    [SerializeField] Transform attackPosition;
    [SerializeField] float radius;
    public LayerMask zoneAttack;
    //[SerializeField] AudioClip ataque;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Attack();
            //ControladorAudios.Intance.EjecutarSonido(ataque);
        }
    }

    public void Attack()
    {
        Collider2D[] attacking = Physics2D.OverlapCircleAll(attackPosition.transform.position, radius, zoneAttack);

        for (int i = 0; i < attacking.Length; i++)
        {
            HidraLvl1 hidra = attacking[i].GetComponent<HidraLvl1>();
            if (hidra != null)
            {
                hidra.TakeDamage(damage);
            }
            HongoLvl1 mush = attacking[i].GetComponent<HongoLvl1>();
            if (mush != null)
            {
                mush.TakeDamage(damage);
            }

            CarnivoraLvl1 carnivora = attacking[i].GetComponent<CarnivoraLvl1>();
            if (carnivora != null)
            {
                carnivora.TakeDamage(damage);
            }

            BossEnemy bossEnemy = attacking[i].GetComponent<BossEnemy>();
            if (bossEnemy != null)
            {
                bossEnemy.RecibirDaño(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition.position, radius);
    }

}
