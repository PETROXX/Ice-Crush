using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class LocationElement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _cooldown = 0.3f;
    private float _lifeTimer = 1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<PunchZone>(out _))
        {
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        for(int i = 0; i < 3; i++)
        {
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y - 0.1f,
                                             transform.position.z);

            yield return new WaitForSeconds(_cooldown);
        }

        _rigidbody.useGravity = true;

        yield return new WaitForSeconds(_lifeTimer);
        Destroy(gameObject);
    }
}
