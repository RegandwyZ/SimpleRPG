using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsAttack = Animator.StringToHash("IsAttack");
    private static readonly int IsHeavyAttack = Animator.StringToHash("IsHeavyAttack");
    private static readonly int IsAttackCombo = Animator.StringToHash("IsAttackCombo");
    private static readonly int IsAttackSpinning = Animator.StringToHash("IsAttackSpinning");
    
    private Animator _animator;
    
    private bool _isAction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isAction = _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") ||
                    _animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack") ||
                    _animator.GetCurrentAnimatorStateInfo(0).IsName("AttackCombo") ||
                    _animator.GetCurrentAnimatorStateInfo(0).IsName("AttackSpinning");
    }
    
    public bool IsAction()
    {
        return _isAction;
    }

    public void SimpleAttackAnimation()
    {
        _animator.SetTrigger(IsAttack);
    }
    
    public void HeavyAttackAnimation()
    {
        _animator.SetTrigger(IsHeavyAttack);
    }
    
    public void ComboAttackAnimation()
    {
        _animator.SetTrigger(IsAttackCombo);
    }
    
    public void SpinningAttackAnimation()
    {
        _animator.SetTrigger(IsAttackSpinning);
    }
    
    public void JumpAnimation()
    {
        _animator.SetTrigger(IsAttack);
    }

    public void IsRunning(bool running)
    {
        _animator.SetBool(IsMoving, running);
    }
}
