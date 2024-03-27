using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyTestMoving _enemy;
    
    private EnemyDamageTakenAnimation _effects;
    private HealthBar _healthBar;
    
    private void Awake()
    {
        _effects = GetComponent<EnemyDamageTakenAnimation>();
        _healthBar = GetComponent<HealthBar>();
        _healthBar.SetMaxHealth(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthBar.SetHealth(_health);
        _effects.Flash();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _animator.Play("Defeat");
            _enemy.Defeat();
        }
    }
}
