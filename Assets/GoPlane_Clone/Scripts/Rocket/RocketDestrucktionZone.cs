using System;
using UnityEngine;

public class RocketDestrucktionZone : ActivatingObject
{
	[SerializeField] private Vibration _vibration;
	
	public event Action<Vector3> Contacted;
	
	public override void Activate()
	{
		isDiactivate = false;
	}

	public override void Diactivate()
	{
		isDiactivate = true;
	}
	
	private void OnTriggerStay(Collider other)
	{
		if (isDiactivate)
			return;
		
		if (other.TryGetComponent(out Rocket rocket))
		{
			OnContacted(rocket);
		}
	}

	private void OnContacted(Rocket rocket)
	{
		Contacted?.Invoke(rocket.transform.position);
		
		rocket.gameObject.SetActive(false);
		
		_vibration.Vibrate();
	}
}