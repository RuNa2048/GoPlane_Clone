using System;

public class StandartMenuButton : MenuButton
{
	public event Action OnClicked;
	
	protected override void Clicked()
	{
		OnClicked?.Invoke();
	}
}
