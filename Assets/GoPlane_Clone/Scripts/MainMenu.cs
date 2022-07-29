using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private GameActivator _gameActivator;
	
	[Header("Windows")]
	[SerializeField] private MenuWindow _menu;
	[SerializeField] private MenuWindow _coinsWindow;
	[SerializeField] private MenuWindow _scoreCounterWindow;
	[SerializeField] private SettingsMenuWindow _settingsWindow;
	
	[Header("Buttons")]
	[SerializeField] private AnimatedMenuButton _settingsButton;

	private void OnEnable()
	{
		_settingsButton.OnClicked += _settingsWindow.Change;

		_gameActivator.OnGameStarted += _menu.Close;
		_gameActivator.OnGameStarted += _coinsWindow.Open;
		_gameActivator.OnGameStarted += _scoreCounterWindow.Open;
		
		_gameActivator.OnGameWaited += _coinsWindow.Close;
		_gameActivator.OnGameWaited += _scoreCounterWindow.Close;
		
		_gameActivator.OnGameEnded += _menu.Open;
	}
	
	private void OnDisable()
	{
		_settingsButton.OnClicked -= _settingsWindow.Change;
		
		_gameActivator.OnGameStarted -= _menu.Close;
		_gameActivator.OnGameStarted -= _coinsWindow.Open;
		_gameActivator.OnGameStarted -= _scoreCounterWindow.Open;
		
		_gameActivator.OnGameWaited -= _coinsWindow.Close;
		_gameActivator.OnGameWaited -= _scoreCounterWindow.Close;
		
		_gameActivator.OnGameEnded -= _menu.Open;
	}
}
