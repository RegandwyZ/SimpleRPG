 using UnityEngine;

 public interface IWeapon
 {
     Collider Collider { get; set; }
     void SetDamage(float damage);
 }
