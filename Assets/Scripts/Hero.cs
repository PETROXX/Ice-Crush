using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hero : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundCheck _groundCheck;

    private List<Rigidbody> _ragdollElements;

    private void Start()
    {
        _ragdollElements = GetComponentsInChildren<Rigidbody>().ToList();
        DisableRagdoll();
        _groundCheck.OnGroundDestroyed += EnableRagdoll;
    }
    private void EnableRagdoll()
    {
        _animator.enabled = false;

        foreach (var ragdollElement in _ragdollElements)
        {
            ragdollElement.isKinematic = false;
        }
    }

    private void DisableRagdoll()
    {
        foreach(var ragdollElement in _ragdollElements)
        {
            ragdollElement.isKinematic = true;
        }

        _animator.enabled = true;
    }
}
