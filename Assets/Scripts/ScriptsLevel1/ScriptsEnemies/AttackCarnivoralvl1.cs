using UnityEngine;

public class AttackCarnivoralvl1 : MonoBehaviour
{
    CarnivoraLvl1 carnivora;

    [SerializeField] GameObject zoneAttack;
    [SerializeField] int damage;
    [SerializeField] PlayerLvl1 player;
    [SerializeField] float radiusAttack;
    [SerializeField] float coolDown;

    private float coolDownAttack = -Mathf.Infinity;
    void Start()
    {
        carnivora = GetComponent<CarnivoraLvl1>();
    }

    private void FixedUpdate()
    {
        Collider2D attackEnemy = Physics2D.OverlapCircle(zoneAttack.transform.position, radiusAttack, carnivora.LayermaskCarnivora);

        if (attackEnemy && Time.time >= coolDownAttack && carnivora.CurrentHealth > 0)
        {
            toAttack();
            coolDownAttack = Time.time + coolDown;
        }

        else
        {
            carnivora.Anim.SetBool("Follow", true);
        }
    }

    public void toAttack()
    {
        carnivora.Anim.SetTrigger("Attack");
        player.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(zoneAttack.transform.position, radiusAttack);
    }
}
