using System;
using UnityEngine;

public class GameModeLauncher : MonoBehaviour
{
	[SerializeField] private GameModeButton[] _gameModeButtons;
	[SerializeField] private GameMode[] _gameModes;

	public event Action OnStandartGameStarted;
	public event Action OnModeStarted;

	private GameActivator _gameActivator;
	
	private GameModeType _lastGameMode = GameModeType.None;

	public void Initialize(GameActivator gameActivator)
	{
		_gameActivator = gameActivator;

		foreach (var mode in _gameModes)
		{
			mode.Initialize(_gameActivator);
		}
		
		foreach (var button in _gameModeButtons)
		{
			button.OnClicked += ActivateSpecificMode;
		}
	}

	private void ActivateSpecificMode(GameModeType type)
	{
		// if (_lastGameMode == type) 
		// {
		// 	_gameActivator.GameStarted();
		// 	
		// 	return;
		// }
		
		foreach (var mode in _gameModes)
		{
			mode.Diactivate();
		}

		foreach (var mode in _gameModes)
		{
			if (mode.Type == type)
			{
				mode.Activate();
				
				_gameActivator.GameStarted();

				CallModeEvent(type);

				_lastGameMode = type;
			}
			// else
			// {
			// 	mode.Diactivate();
			// }
		}
	}

	private void CallModeEvent(GameModeType type)
	{
		if (type == GameModeType.Standart)
		{
			OnStandartGameStarted?.Invoke();
		}
		else
		{
			OnModeStarted?.Invoke();
		}
	}

}