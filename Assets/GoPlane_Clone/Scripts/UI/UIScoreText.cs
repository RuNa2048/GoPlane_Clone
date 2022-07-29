using UnityEngine;

public class UIScoreText : UIText
{
	[SerializeField] private ScoreCounter _scoreCounter;

	private void OnEnable()
	{
		_scoreCounter.OnAmountChanged += Change;
	}
	
	private void OnDisable()
	{
		_scoreCounter.OnAmountChanged -= Change;
	}

	private void Start()
	{
		text.text = "0";
	}
}