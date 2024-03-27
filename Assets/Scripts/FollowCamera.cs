using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    [SerializeField] private Vector3 _offset = new Vector3(12.5f, 11f, 15f);
    [SerializeField] private float rotationSpeed = 5f; 

    private Vector3 _targetOffset; 

    private void Start()
    {
        _targetOffset = _offset;
    }
    private void LateUpdate()
    {
        _offset = Vector3.Lerp(_offset, _targetOffset, rotationSpeed * Time.deltaTime);

        transform.position = _player.position + _offset;
        transform.LookAt(_player);

        if (Input.GetKeyDown(KeyCode.C))
            RotateCamera();
        
    }

    private void RotateCamera()
    {
        _targetOffset = Quaternion.Euler(0, 90, 0) * _targetOffset;
    }
}
