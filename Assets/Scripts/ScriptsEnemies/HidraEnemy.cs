using Unity.VisualScripting;
using UnityEngine;

public class HidraEnemy : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] GameObject gizmo;
    [SerializeField] float radius;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float _speed;
    Rigidbody2D _rb;
    Animator _animator;
    private float health;
    private int damage;
   
    private float currentHealth;

    public Rigidbody2D RbHidra { get => _rb; set => _rb = value; }
    public Animator AnimatorHidra { get => _animator; set => _animator = value; }
    public GameObject TargetHidra { get => _target; set => _target = value; }
    public float SpeedHidra { get => _speed; set => _speed = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(transform.position, radius, layerMask);
        if (zona)
        {
            _animator.SetBool("Seguir", zona);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
