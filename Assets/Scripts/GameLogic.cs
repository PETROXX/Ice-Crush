using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Location _location;
    [SerializeField] private Hammer _hammer;
    [SerializeField] private List<RoadToWall> _roadsToWall;

    public event Action OnGameWon;
    public event Action OnGameOver;

    private const int _chanceToFail = 25;
    private const int _timeToRestartScene = 3;

    private bool _canGameBeWon; 

    private void Start()
    {
        _canGameBeWon = _chanceToFail < Random.Range(0, 100);

        _location.OnBlocksLimitReached += CheckRoutesToWalls;

        foreach (var roadToWall in _roadsToWall)
        {
            roadToWall.OnRoadToWallBroken += RemoveRoadRoadToWall;
        }
    }

    private void RemoveRoadRoadToWall(RoadToWall roadToWall)
    {
        _roadsToWall.Remove(roadToWall);

        if (!_canGameBeWon)
            GameOver();

        if (_roadsToWall.Count == 0)
            GameOver();
        
    }

    private void CheckRoutesToWalls()
    {
        if (_roadsToWall.Count > 0)
            Victory();
        else
            GameOver();
    }

    private void Victory()
    {
        OnGameWon?.Invoke();
        StartCoroutine(RestartGame());
    }

    private void GameOver()
    {
        OnGameOver?.Invoke();
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(_timeToRestartScene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
