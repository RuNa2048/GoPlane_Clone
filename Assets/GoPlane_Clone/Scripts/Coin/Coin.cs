using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public event Action OnRaised;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Character character))
		{
			Raised();
		}
	}

	private void Raised()
	{
		OnRaised?.Invoke();
		
		gameObject.SetActive(false);
	}
}
