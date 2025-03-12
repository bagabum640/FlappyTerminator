using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _value = 0;

    public event Action<int> ScoreChanged;

    private void Awake()
    {
        ScoreChanged?.Invoke(_value);
    }

    public void Add()
    {
        _value++;
        ScoreChanged?.Invoke(_value);
    }
}