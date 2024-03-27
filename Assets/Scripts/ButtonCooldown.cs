using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _cooldownImage;
    [SerializeField] private TextMeshProUGUI _cooldownText; 
    [SerializeField] private float _cooldownDuration = 5f;
    
    private AttackAnimation _attackAnimation;
    
    private float _cooldownTimer = 0;

    private void Awake()
    {
        _attackAnimation = GetComponentInParent<AttackAnimation>();
    }

    private void Update()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            _cooldownImage.fillAmount = _cooldownTimer / _cooldownDuration;
            _cooldownText.text = Mathf.Ceil(_cooldownTimer).ToString(); 
        }
        else
        {
            _cooldownImage.fillAmount = 0;
            _button.interactable = true;
            _cooldownText.text = ""; 
        }
    }

    public void StartCooldown()
    {
        if (_cooldownTimer <= 0 && !_attackAnimation.IsAction())
        {
            _cooldownTimer = _cooldownDuration;
            _button.interactable = false;
        }
    }
}