 using UnityEngine;

 public class PlayerWeapon : MonoBehaviour, IWeapon
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
         if (other.gameObject.CompareTag("Enemy"))
         {
             var enemy = other.gameObject.GetComponent<EnemyHealthSystem>();
             if (enemy != null)
             {
                 enemy.TakeDamage(Damage);
             }
         }
     }
     
 }