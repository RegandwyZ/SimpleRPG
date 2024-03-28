using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;

    private DamageTakenEffect _effects;
    private HealthBar _healthBar;
    
    private void Awake()
    {
        _effects = GetComponentInChildren<DamageTakenEffect>();
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
        }
    }
}
