using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
	[SerializeField] private SavedData _savedData;
	
	public event Action<int> OnAmountChanged;
	
	private List<Coin> _coins;

	private int _currentAmountCoins;

	public void Initialize(List<Coin> coins)
	{
		_coins = coins;
		
		foreach (var coin in _coins)
		{
			coin.OnRaised += IncreaseAmountByOne;
		}
		
		_currentAmountCoins = _savedData.GetCoinsAmount();

		AmountChanged();
	}

	private void OnDisable()
	{
		foreach (var coin in _coins)
		{
			coin.OnRaised -= IncreaseAmountByOne;
		}
	}

	private void AmountChanged()
	{
		_savedData.SaveCoins(_currentAmountCoins);
		
		OnAmountChanged?.Invoke(_currentAmountCoins);
	}

	private void IncreaseAmountByOne()
	{
		_currentAmountCoins++;

		AmountChanged();
	}
}
