using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
	[Header("Moving")]
	[SerializeField] private float _movingSpeed = 5f; 
	[SerializeField] private float _rotationSpeed = 3f;

	[Header("Player")]
	[SerializeField] private PlayerMoving _player;
	
	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		ChangeDirection();
		
		ForwardMoving();
	}

	private void ChangeDirection()
	{
		Vector3 direction = _player.RigidbodyPosition - _rigidbody.position;
		direction.Normalize();

		float rotation = Vector3.Cross(direction, transform.up).z;

		Vector3 angularVelocity = Vector3.zero;
		angularVelocity.z = -rotation * _rotationSpeed;
		
		_rigidbody.angularVelocity = angularVelocity;
	}
	
	private void ForwardMoving()
	{
		_rigidbody.velocity = transform.up * _movingSpeed;
	}
}
