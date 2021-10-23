using System.Collections.Generic;
using UnityEngine;
using System;

public class Location : MonoBehaviour
{
    [SerializeField] private List<LocationElement> _locationElements;
    [SerializeField] private GameLogic _gameLogic;

    private int _maxLocationsElementsCount;

    public event Action OnBlocksLimitReached;
    public float LocationIntactPercent { get; private set; }

    private void Start()
    {
        LocationIntactPercent = 100;
        _maxLocationsElementsCount = _locationElements.Count;
        _gameLogic.OnGameOver += DestroyAllElements;
    }

    public void RemoveLocationElement(LocationElement locationElement)
    {
        if (_locationElements.Contains(locationElement))
            _locationElements.Remove(locationElement);

        LocationIntactPercent = GetLocationIntactPercent();

        if (LocationIntactPercent <= 0.2)
            OnBlocksLimitReached?.Invoke();
    }

    private float GetLocationIntactPercent()
    {
        return (float)_locationElements.Count / (float)_maxLocationsElementsCount;
    }

    private void DestroyAllElements()
    {
        foreach (var locationElement in _locationElements)
        {
            locationElement.StartDestructionTimer();
        }
    }
}
