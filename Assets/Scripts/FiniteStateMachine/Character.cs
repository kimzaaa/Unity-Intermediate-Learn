using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Rigidbody _rigidbody;
    
    [Header("Character Properties")]
    [SerializeField] protected int _maxHealth = 20;
    [SerializeField] protected int _atkDamage = 1;
    
    [Header("Movement Properties")]
    [SerializeField] protected float _walkSpeed = 1f;
    [SerializeField] protected float _runSpeed = 2f;
    [SerializeField] protected  float _jumpForce = 10f;

    protected int _health = 20;

    protected float _speed;
    protected bool _isRunning = false;

    protected virtual void Awake(){
        _speed = _walkSpeed;
        _health = _maxHealth;
    }
    public virtual void Attack(Character target){
        target.TakeDamage(_atkDamage);
    }
    public virtual void TakeDamage(int damage){
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }
    public virtual void Die(){
        Destroy(gameObject);
    }
}

