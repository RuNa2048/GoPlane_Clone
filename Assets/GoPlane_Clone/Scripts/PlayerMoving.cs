using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
	[Header("Moving Parameters")]
	[SerializeField] private float _speed;
	[SerializeField] private float _rotationSpeed;

	[SerializeField] private DynamicJoystick _joystick;

	public void Direction(Vector2 direction) => _direction = direction;
	public Vector3 RigidbodyPosition => _rigidbody.position;
	
	private Rigidbody _rigidbody;
	private Vector2 _direction;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		_rigidbody.velocity = transform.up * _speed;

		Rotate();
	}

	public void Rotate()
	{
		if (Mathf.Abs(_joystick.Horizontal) < 0.01f || Mathf.Abs(_joystick.Vertical) < 0.01f)
			return;
		
		Vector3 direction = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0f);

		transform.up = Vector3.Slerp(transform.up, direction, Time.fixedDeltaTime * _rotationSpeed);
	}
}
