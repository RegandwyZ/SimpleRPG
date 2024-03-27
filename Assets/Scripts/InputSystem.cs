using UnityEngine;
using UnityEngine.AI;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private AttackAnimation _attackAnimation;
    [SerializeField] private NavMeshAgent _agent;
    
    private float _horizontalInput;
    private float _verticalInput;

    private void Update()
    {
        var isMoving = Mathf.Abs(_horizontalInput) > 0.1f || Mathf.Abs(_verticalInput) > 0.1f;
        _attackAnimation.IsRunning(isMoving);

        if (_attackAnimation.IsAction()) return;
        
        _horizontalInput = _joystick.Horizontal;
        _verticalInput = _joystick.Vertical;
            
        MoveAgentRelativeToCamera();

    }

    private void MoveAgentRelativeToCamera()
    {
        var forward = _cameraTransform.forward;
        var right = _cameraTransform.right;
        
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        
        var moveDirection = (forward * _verticalInput + right * _horizontalInput).normalized;
        
        _agent.Move(moveDirection * (Time.deltaTime * _agent.speed));

        if (moveDirection == Vector3.zero) return;
        _agent.Move(moveDirection * (Time.deltaTime * _agent.speed));
        
        var targetRotation = Quaternion.LookRotation(moveDirection);
        _agent.transform.rotation = Quaternion.Slerp(_agent.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

  
}
