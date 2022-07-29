using UnityEngine;

public class UICoinsText : UIText
{
	[SerializeField] private CoinCounter _coinCounter;

	private void OnEnable()
	{
		_coinCounter.OnAmountChanged += Change;
	}
	
	private void OnDisable()
	{
		_coinCounter.OnAmountChanged -= Change;
	}
}
