using System;
using UnityEngine;

public class OpenWindowButton : MenuButton
{
	[SerializeField] private MenuWindow _openingWindow;

	public event Action<MenuWindow> OnClicked;
	
	protected override void Clicked()
	{
		OnClicked?.Invoke(_openingWindow);
	}
}
