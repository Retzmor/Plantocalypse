using UnityEngine;

public class AttackHidraLvl1 : MonoBehaviour
{
    HidraLvl1 hidra;
    [SerializeField] GameObject zonaAttackGizmo;
    [SerializeField] PlayerLvl1 player;
    [SerializeField] float radiusAttack;
    [SerializeField] int damage;
    [SerializeField] float coolDownAttack;
    private float coolDown = -Mathf.Infinity;

    void Start()
    {
        hidra = GetComponent<HidraLvl1>();
    }

    private void FixedUpdate()
    {
        Collider2D zonaAttack = Physics2D.OverlapCircle(zonaAttackGizmo.transform.position, radiusAttack, hidra.LayerMaskHidra);
        if (zonaAttack && Time.time >= coolDown && hidra.CurrentHealth > 0)
        {
            ToAttack();
            coolDown = Time.time + coolDownAttack;
        }
        else
        {
            hidra.AnimatorHidra.SetBool("Seguir", true);
        }
    }

    public void ToAttack()
    {
        hidra.AnimatorHidra.SetTrigger("Atacar");
        player.RecibirDaño(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(zonaAttackGizmo.transform.position, radiusAttack);
    }
}
