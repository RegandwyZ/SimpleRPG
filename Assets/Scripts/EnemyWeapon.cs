using UnityEngine;

public class EnemyWeapon : MonoBehaviour, IWeapon
{
    public Collider Collider { get; set; }
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
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerHealthSystem>();
            if (player != null)
            {
                player.TakeDamage(Damage);
            }
        }
    }
}