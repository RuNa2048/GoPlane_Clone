using UnityEngine;

public class SavedData : MonoBehaviour
{
	private string _scoreKey = "score";
	private string _coinsKey = "coins";

	public void SaveScore(int currentScore)
	{
		PlayerPrefs.SetInt(_scoreKey, currentScore);
	}

	public int GetScore()
	{
		return PlayerPrefs.GetInt(_scoreKey);
	}
	
	public void SaveCoins(int coins)
	{
		PlayerPrefs.SetInt(_coinsKey, coins);
	}

	public int GetCoinsAmount()
	{
		return PlayerPrefs.GetInt(_coinsKey);
	}
}
