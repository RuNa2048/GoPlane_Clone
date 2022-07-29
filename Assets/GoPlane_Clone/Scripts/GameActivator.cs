using System;
using UnityEngine;

public class GameActivator: MonoBehaviour
{
	public event Action OnGameStarted;
	public event Action OnGameWaited;
	public event Action OnGameEnded;

	public void GameStarted()
	{
		OnGameStarted?.Invoke();
	}

	public void GameWaited()
	{
		OnGameWaited?.Invoke();
	}

	public void GameEnded()
	{
		OnGameEnded?.Invoke();
	}
}