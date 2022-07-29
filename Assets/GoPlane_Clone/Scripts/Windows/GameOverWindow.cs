using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
	[Header("Windows")]
	[SerializeField] private MenuWindow _waitingWindow;
	[SerializeField] private MenuWindow _endGameWindow;
	[SerializeField] private MenuWindow _endModeWindow;
	[SerializeField] private MenuWindow _footerWindow;
	[SerializeField] private HighScoreWindow _highScoreWindow;

	[Header("Buttons")]
	//[SerializeField] private StandartMenuButton _continueButton;
	[SerializeField] private StandartMenuButton _endButton;

	[Header("References")]
	[SerializeField] private GameActivator _gameActivator;
	
	private void OnEnable()
	{
		_gameActivator.OnGameWaited += _waitingWindow.Open;

		_endButton.OnClicked += _gameActivator.GameEnded;
		_endButton.OnClicked += _endGameWindow.Open;
		_endButton.OnClicked += _highScoreWindow.SetScore;
		_endButton.OnClicked += _waitingWindow.Close;
	}
	
	private void OnDisable()
	{
		_gameActivator.OnGameWaited -= _waitingWindow.Open;

		_endButton.OnClicked -= _endGameWindow.Open;
		_endButton.OnClicked -= _highScoreWindow.SetScore;
		_endButton.OnClicked -= _waitingWindow.Close;
		_endButton.OnClicked -= _gameActivator.GameEnded;
	}
}
