using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Hammer _hammer;
    [SerializeField] private GameLogic _gameLogic;

    public static string WasGameWon = "WasGameWon";
    public static string WasPunchPerformed = "WasPunchPerformed";

    private void Start()
    {
        _hammer.OnPunchStarted += OnPunchStartedAnimation;
        _hammer.OnPunchFinished += OnPunchFinishedAnimation;
        _gameLogic.OnGameWon += OnGameWonAnimation;
    }

    private void OnPunchStartedAnimation()
    {
        _animator.SetBool(WasPunchPerformed, true);
    }

    private void OnPunchFinishedAnimation()
    {
        _animator.SetBool(WasPunchPerformed, false);
    }

    private void OnGameWonAnimation()
    {
        _animator.SetBool(WasGameWon, true);
    }
}
