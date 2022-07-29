using System;
using UnityEngine;

public class EndButton : MenuButton
{
	[SerializeField] private GameActivator _gameActivator;

	public event Action OnClicked;
	
	protected override void Clicked()
	{
		_gameActivator.GameEnded();
		
		OnClicked?.Invoke();
	}
}
