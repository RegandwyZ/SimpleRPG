using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBillBoard : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void LateUpdate()
    {
        var rotation = _mainCamera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
            rotation * Vector3.up);
    }
}
