using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	[Header("Save")]
	[SerializeField] private SavedData _savedData;

	public event Action<int> OnAmountChanged;

	private int _currentScore = 0;
	public int CurrentScore => _currentScore;

	public void Increase(int increaseValue)
	{
		_currentScore += increaseValue;
		
		OnAmountChanged?.Invoke(_currentScore);
	}

	public void Reset()
	{
		_currentScore = 0;
		
		OnAmountChanged?.Invoke(_currentScore);
	}
}
