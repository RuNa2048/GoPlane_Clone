using System;
using UnityEngine;

public class GameModeButton : MenuButton
{
	[SerializeField] private GameModeType _gameModeType;

	public event Action<GameModeType> OnClicked;

	protected override void Clicked()
	{
		OnClicked?.Invoke(_gameModeType);
	}
}

