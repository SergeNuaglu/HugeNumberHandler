using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelIncreaser : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private int _clickCount;

    private int _levelNumber = 1;
    private int _currentRank = 0;
    private int _denominator = 1000;
    private float _nextLevelCost;
    private float _minLevelCost = 0.5f;
    private float _baseDegree = 2.6f;
    private readonly string[] _ranks = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                                        "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                                        "u", "v", "w", "x","y","z" };

    private void Start()
    {
        _price.text = (_minLevelCost * _denominator).ToString();
        _level.text = _levelNumber.ToString();
    }

    public void Increase()
    {
        int minRankIndex = 0;

        /* for (int i = 0; i < _clickCount-1; i++)
         {
             if (_currentRank <= minRankIndex)
                 IncreasePriceByPowerFunction();
             else
                 IncreasePriceByPercent();
         }
        */

        if (_currentRank <= minRankIndex)
            IncreasePriceByPowerFunction();
        else
            IncreasePriceByPercent();
    }

    private void IncreasePriceByPowerFunction()
    {
        _nextLevelCost = _minLevelCost * Mathf.Pow(++_levelNumber, 2.6f + 0.013f * _levelNumber);
        _nextLevelCost = (float)Math.Round(_nextLevelCost, 1);
        Render();
    }

    public void IncreasePriceByPercent()
    {
        float rankСoefficient = 0.052f + (float)_currentRank / 1000;
        float stepPercent = 0.23f - rankСoefficient;
        _nextLevelCost += _nextLevelCost * stepPercent;
        _levelNumber++;
        Render();
    }

    private void Render()
    {
        if (_nextLevelCost >= _denominator)
        {
            _currentRank++;
            _nextLevelCost /= _denominator;

            if (_currentRank >= _ranks.Length - 1)
                _currentRank = _ranks.Length - 1;
        }

        _nextLevelCost = (float)Math.Round(_nextLevelCost, 1);
        _price.text = _nextLevelCost.ToString() + _ranks[_currentRank];
        _level.text = _levelNumber.ToString();
    }
}
