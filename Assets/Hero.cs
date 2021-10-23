using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<DeathZone>(out _))
            Destroy(gameObject);
    }
}
