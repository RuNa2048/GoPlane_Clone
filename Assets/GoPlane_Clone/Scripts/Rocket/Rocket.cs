using System;
using UnityEngine;

[RequireComponent(typeof(RocketMoving))]
public class Rocket : MonoBehaviour
{
	public event Action OnHittedWithCharacter;
	public event Action<Vector3> OnHittedWithRocket;

	private Vibration _vibration;
	private RocketMoving _rocketMoving;

	private bool _isCanHittedWithCharacter;
	private bool _isCanHittedWithRocket;

	public void Initialize(CharacterMoving character)
	{
		_rocketMoving = GetComponent<RocketMoving>();

		_rocketMoving.Initialize(character);

		_isCanHittedWithCharacter = true;
		_isCanHittedWithRocket = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Character character))
		{
			HittedWithCharacter();
		}

		if (other.TryGetComponent(out Rocket rocket))
		{
			HittedWithOtherRocket(rocket);
		}
	}

	private void HittedWithCharacter()
	{
		gameObject.SetActive(false);

		if (!_isCanHittedWithCharacter)
			return;

		OnHittedWithCharacter?.Invoke();
	}

	private void HittedWithOtherRocket(Rocket otherRocket)
	{
		if (!_isCanHittedWithRocket)
			return;
		
		otherRocket._isCanHittedWithRocket = false;
		otherRocket.gameObject.SetActive(false);
		
		OnHittedWithRocket?.Invoke(transform.position);
		
		gameObject.SetActive(false);
		
		_vibration.Vibrate();
	}

	public void TurnOnHitWithPlayer()
	{
		_isCanHittedWithCharacter = true;
	}

	public void TurnOffHitWithPlayer()
	{
		_isCanHittedWithCharacter = false;
	}
}
