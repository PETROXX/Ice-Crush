using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundCheck : MonoBehaviour
{
    public event Action OnGroundDestroyed;

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<LocationElement>(out _))
        {
            OnGroundDestroyed?.Invoke();
        }
    }
}
