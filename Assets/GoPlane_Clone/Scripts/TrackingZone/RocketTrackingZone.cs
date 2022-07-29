using System;
using UnityEngine;

public class RocketTrackingZone : ActivatingObject
{

	public event Action OnHasEntered;
	public event Action OnCameOut;
	
	private int _countRocketsInZone;
	
	public override void Activate()
	{
		isDiactivate = false;
	}

	public override void Diactivate()
	{
		isDiactivate = true;

		ResetCountRockets();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isDiactivate)
			return;
		
		if (other.TryGetComponent(out Rocket rocket))
		{
			_countRocketsInZone++;
			
			OnHasEntered?.Invoke();
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (isDiactivate)
			return;

		if (other.TryGetComponent(out Rocket rocket))
		{
			_countRocketsInZone--;
			
			if (_countRocketsInZone == 0)
			{
				OnCameOut?.Invoke();
			}
		}
	}

	private void ResetCountRockets() => _countRocketsInZone = 0;
}