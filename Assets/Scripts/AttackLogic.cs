using System;
using System.Collections;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    [SerializeField] private AttackAnimation _attackAnimation;
    [SerializeField] private float normalAttackDamage = 10f;
    [SerializeField] private float heavyAttackDamage = 20f;
    [SerializeField] private float comboAttackDamage = 15f;
    [SerializeField] private float spinningAttackDamage = 25f;
    
    [SerializeField] private MonoBehaviour _leftHandWeapon;
    [SerializeField] private MonoBehaviour _rightHandWeapon;

    private IWeapon _leftHand;
    private IWeapon _rightHand;

    private void Awake()
    {
        _leftHand = _leftHandWeapon as IWeapon;
        _rightHand = _rightHandWeapon as IWeapon;
    }
   
    

    private void ActivatedWeaponCollider()
    {
        _leftHand.Collider.enabled = true;
        _rightHand.Collider.enabled = true;
    }

    private void DeActivatedWeaponCollider()
    {
        _leftHand.Collider.enabled = false;
        _rightHand.Collider.enabled = false;
    }
    
    private void PerformAttack(float damage, Action animationAction)
    {
        if (_attackAnimation.IsAction()) return;
        
        animationAction.Invoke();
        _leftHand.SetDamage(damage);
        _rightHand.SetDamage(damage);
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
