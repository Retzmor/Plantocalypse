using UnityEngine;

public class AttackCarnivora : MonoBehaviour
{
    Carnivora carnivora;

    [SerializeField] GameObject zoneAttack;
    [SerializeField] int damage;
    [SerializeField] PlayerMovement pMovement;
    [SerializeField] float radiusAttack;
    [SerializeField] float coolDown;

    private float coolDownAttack = -Mathf.Infinity;
    void Start()
    {
        carnivora = GetComponent<Carnivora>();
    }

    private void FixedUpdate()
    {
        Collider2D attackEnemy = Physics2D.OverlapCircle(zoneAttack.transform.position,radiusAttack,carnivora.LayermaskCarnivora);

        if (attackEnemy && Time.time - coolDownAttack >= coolDown && carnivora.CurrentHealth > 0)
        {
            toAttack();
            coolDownAttack = Time.time;
        }
    }

    public void toAttack()
    {
        carnivora.Anim.SetTrigger("Attack");
        pMovement.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(zoneAttack.transform.position,radiusAttack);
    }
}
