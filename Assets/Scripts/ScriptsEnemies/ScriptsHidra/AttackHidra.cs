using Unity.VisualScripting;
using UnityEngine;

public class AttackHidra : MonoBehaviour
{
    HidraEnemy hEnemy;
    [SerializeField] GameObject zonaAttackGizmo;
    [SerializeField] PlayerMovement pMovement;
    [SerializeField] float radiusAttack;
    [SerializeField] int damage;
    [SerializeField] float coolDownAttack;
    private float coolDown = - Mathf.Infinity;

    void Start()
    {
        hEnemy = GetComponent<HidraEnemy>();
    }

    private void FixedUpdate()
    {
        Collider2D zonaAttack = Physics2D.OverlapCircle(zonaAttackGizmo.transform.position,radiusAttack, hEnemy.LayerMaskHidra);
        if (zonaAttack && Time.time - coolDownAttack >= coolDown && hEnemy.CurrentHealth > 0)
        {
            ToAttack();
            coolDown = Time.time; 
        }
    }

    public void ToAttack()
    {
        hEnemy.AnimatorHidra.SetTrigger("Atacar");
        pMovement.RecibirDaño(damage);  
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(zonaAttackGizmo.transform.position,radiusAttack);
    }
}
