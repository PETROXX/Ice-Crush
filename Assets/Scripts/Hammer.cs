using UnityEngine;
using System;

public class Hammer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private HammerMovement _hammerMovement;
    [SerializeField] private BoxCollider _punchZoneCollider;
    [SerializeField] private GameObject _hitEffect;

    public static string IsPunching = "IsPunching";
    public event Action OnPunchStarted;
    public event Action OnPunchFinished;

    private float _yPosition;

    private bool _wasPunchPerfomed;
    private bool _isHammerMovingBack;

    private void Start()
    {
        _yPosition = transform.position.y;
    }
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Ended)
            {
                _wasPunchPerfomed = true;
                _hammerMovement.enabled = false;
            }
        }

        if (_wasPunchPerfomed)
        {
            Vector3 _endPosition = new Vector3(transform.position.x, _yPosition - 1.8f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed);

            if (transform.position == _endPosition)
            {
                Punch();
                _wasPunchPerfomed = false;
            }
        }

        if (_isHammerMovingBack)
        {
            Vector3 _endPosition = new Vector3(transform.position.x, _yPosition, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _endPosition, _speed);

            if (transform.position == _endPosition)
            {
                _isHammerMovingBack = false;
            }
        }
    }

    private void Punch()
    {
        _animator.SetBool(IsPunching, true);
        _punchZoneCollider.enabled = true;
        OnPunchStarted?.Invoke();
    }

    public void FinishPunch()
    {
        _animator.SetBool(IsPunching, false);

        _hammerMovement.enabled = true;
        _isHammerMovingBack = true;
        _punchZoneCollider.enabled = false;
        OnPunchFinished?.Invoke();
    }

    public void EnableHitEffect()
    {
        _hitEffect.SetActive(true);
    }

    public void DisableHitEffect()
    {
        _hitEffect.SetActive(false);
    }
}
