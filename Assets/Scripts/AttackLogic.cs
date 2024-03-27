using System;
using System.Collections;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    [SerializeField] private AttackAnimation _attackAnimation;
    
    [SerializeField] private Weapon _leftHandWeapon;
    [SerializeField] private Weapon _rightHandWeapon;

    [SerializeField] private float normalAttackDamage = 10f;
    [SerializeField] private float heavyAttackDamage = 20f;
    [SerializeField] private float comboAttackDamage = 15f;
    [SerializeField] private float spinningAttackDamage = 25f;


    private void ActivatedWeaponCollider()
    {
        _leftHandWeapon.Collider.enabled = true;
        _rightHandWeapon.Collider.enabled = true;
    }

    private void DeActivatedWeaponCollider()
    {
        _leftHandWeapon.Collider.enabled = false;
        _rightHandWeapon.Collider.enabled = false;
    }
    
    private void PerformAttack(float damage, Action animationAction)
    {
        if (_attackAnimation.IsAction()) return;
        
        animationAction.Invoke();
        _leftHandWeapon.SetDamage(damage);
        _rightHandWeapon.SetDamage(damage);
        StartCoroutine(ActivateWeaponsColliderWithDelay());
    }
    
    private IEnumerator ActivateWeaponsColliderWithDelay()
    {
        yield return new WaitForSeconds(0.15f);
        ActivatedWeaponCollider(); 
        
        yield return new WaitForSeconds(0.5f);
        DeActivatedWeaponCollider(); 
    }
    
    public void Attack()
    {
        PerformAttack(normalAttackDamage, _attackAnimation.SimpleAttackAnimation);
    }
    
    public void HeavyAttack()
    {
        PerformAttack(heavyAttackDamage, _attackAnimation.HeavyAttackAnimation);
    }
    
    public void ComboAttack()
    {
        PerformAttack(comboAttackDamage, _attackAnimation.ComboAttackAnimation);
    }
    
    public void SpinningAttack()
    {
        PerformAttack(spinningAttackDamage, _attackAnimation.SpinningAttackAnimation);
    }
    
    public void Block()
    {
        
    }
    
   
}
