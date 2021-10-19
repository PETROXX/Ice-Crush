using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHammerPosition : MonoBehaviour
{
    [SerializeField] private Transform _hammer;

    private void Update()
    {
        transform.position = new Vector3(_hammer.position.x, transform.position.y, _hammer.position.z);
    }
}
