using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EmojiAnimation : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    public static string AnimationName = "WasAnimationTriggered";

    protected virtual void Start()
    {
        gameObject.SetActive(false);
    }

    protected void StartAnimation()
    {
        gameObject.SetActive(true);
        _animator.SetBool(AnimationName, true);
    }

    protected void AnimationFinished()
    {
        _animator.SetBool(AnimationName, false);
        gameObject.SetActive(false);
    }
}
