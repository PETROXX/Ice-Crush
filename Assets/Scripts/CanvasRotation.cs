using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Update()
    {
        transform.LookAt(_camera.position);
    }
}
