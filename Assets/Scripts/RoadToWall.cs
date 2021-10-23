using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoadToWall : MonoBehaviour
{
    private List<LocationElement> _locationElements = new List<LocationElement>();

    public event Action<RoadToWall> OnRoadToWallBroken;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out LocationElement locationElement))
        {
            _locationElements.Add(locationElement);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnRoadToWallBroken?.Invoke(this);
        Destroy(gameObject);
    }
}
