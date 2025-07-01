using UnityEngine;

public class AttackHongoLvl1 : MonoBehaviour
{
    HongoLvl1 hongo;
    [SerializeField] PlayerLvl1 player;
    [SerializeField] float radiusAttack;
    [SerializeField] GameObject zoneAttack;
    [SerializeField] int damage;
    [SerializeField] float coolDown;
    private float coolDownAttack = -Mathf.Infinity;

    void Start()
    {
        hongo = GetComponent<HongoLvl1>();
    }

    private void FixedUpdate()
    {
        Collider2D attack = Physics2D.OverlapCircle(zoneAttack.transform.position, radiusAttack, hongo.LayermaskMushRoom);
        if (attack && Time.time - coolDownAttack >= coolDown && hongo.CurrentHealth > 0)
        {
            ToAttack();
            coolDownAttack = Time.time;
        }

        else
        {
            hongo.AnimatorMushroom.SetBool("Follow", true);
        }

    }

    public void ToAttack()
    {
        hongo.AnimatorMushroom.SetTrigger("Attack");
        player.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(zoneAttack.transform.position, radiusAttack);
    }
}
