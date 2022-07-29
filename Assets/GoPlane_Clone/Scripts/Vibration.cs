using UnityEngine;

public class Vibration : ActivatingObject
{
	public override void Activate()
	{
		isDiactivate = false;
	}

	public override void Diactivate()
	{
		isDiactivate = true;
	}

	public void Vibrate()
	{
		if (isDiactivate)
			return;
		
		Handheld.Vibrate();
	}
}
