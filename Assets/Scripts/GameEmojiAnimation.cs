using UnityEngine;

public class GameEmojiAnimation : EmojiAnimation
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private EmojiType _emojiType;

    protected override void Start()
    {
        if (_emojiType == EmojiType.Win)
            _gameLogic.OnGameWon += StartAnimation;
        else
            _gameLogic.OnGameOver += StartAnimation;

        base.Start();
    }

    protected enum EmojiType
    {
        Win,
        Lose
    }
}
