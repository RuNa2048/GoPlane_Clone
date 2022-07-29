using UnityEngine;

public class HighScoreWindow : MonoBehaviour
{
	[Header("References On Game Logic Objects ")]
	[SerializeField] private ScoreCounter _scoreCounter;
	[SerializeField] private SavedData _savedData;

	[Header("References On Text Components")]
	[SerializeField] private UIText _currentScoreText;
	[SerializeField] private UIText _maxScoreText;
	
	public void SetScore()
	{
		var currentScore = _scoreCounter.CurrentScore;
		
		_currentScoreText.Change(currentScore);

		var maxScore = CheckMax(currentScore);

		var maxScoreText = $"BEST {maxScore}";
		
		_maxScoreText.Change(maxScoreText);
	}

	private int CheckMax(int currentScore)
	{
		var maxScore = _savedData.GetScore();
		
		if (currentScore > maxScore)
		{
			_savedData.SaveScore(currentScore);

			return currentScore;
		}

		return maxScore;
	}
}