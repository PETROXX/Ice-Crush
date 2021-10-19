using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _locationCenter;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * _speed,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * _speed);
            }
        }
    }

    private void LateUpdate()
    {
       // UpdateRotation();
    }

    private void UpdateRotation()
    {
        Vector3 direction = transform.position - _locationCenter.position;
        Quaternion lookRot = Quaternion.LookRotation(direction);

        transform.rotation = lookRot;

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
