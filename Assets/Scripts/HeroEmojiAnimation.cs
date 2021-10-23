using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEmojiAnimation : EmojiAnimation
{
    [SerializeField] private Hammer _hammer;

    protected override void Start()
    {
        _hammer.OnPunchStarted += StartAnimation;
        base.Start();
    }
}
