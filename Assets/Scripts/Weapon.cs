using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Collider Collider;
    private float Damage { get; set; }

    private void Awake()
    {
        Collider = GetComponent<Collider>();
    }
    
    public void SetDamage(float damage)
    {
        Damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyHealthSystem>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
    }
    
}
