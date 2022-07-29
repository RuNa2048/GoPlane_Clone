using System;
using UnityEngine;

public class CharacterMoving : ActivatingObject
{
	[Header("Moving Parameters")]
	[SerializeField] private float _speed;
	[SerializeField] private float _rotationSpeed;

	[SerializeField] private GameObject _body;
	
	private Rigidbody _rigidbody;
	public Vector3 RigidbodyPosition => _rigidbody.position;

	private float _lastHorizontalDirection; 

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	public override void Activate()
	{
		isDiactivate = false;

		transform.up = Vector3.up;
	}

	public override void Diactivate()
	{
		isDiactivate = true;
	}

	private void FixedUpdate()
	{
		_rigidbody.velocity = transform.up * _speed;
	}

	public void Rotate(Vector2 input)
	{
		if (isDiactivate)
			return;
		
		if (Mathf.Abs(input.x) < 0.01f || Mathf.Abs(input.y) < 0.01f)
			return;
		
		Vector3 direction = new Vector3(input.x, input.y, 0f);

		//RotateBody(direction.x);
		
		transform.up = Vector3.Slerp(transform.up, direction, Time.deltaTime * _rotationSpeed);

		_lastHorizontalDirection = transform.up.x;
	}

	private void RotateBody(float xDirection)
	{
		if (xDirection < _lastHorizontalDirection)
		{
			_body.transform.Rotate(Vector3.up * -35f);
		}
		else if (xDirection > _lastHorizontalDirection)
		{
			_body.transform.Rotate(Vector3.up * 35f);
		}

		if (Math.Abs(xDirection - _lastHorizontalDirection) < 0.1f)
		{
			_body.transform.Rotate(Vector3.up);
		}
	}
}
