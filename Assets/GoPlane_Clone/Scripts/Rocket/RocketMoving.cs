using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketMoving : MonoBehaviour
{
	[Header("Moving")]
	[SerializeField] private float _movingSpeed = 5f; 
	
	[Header("Rotation")]
	[SerializeField] private float _standartRotationSpeed = 3f;
	[SerializeField] private float _accetleratedRotationSpeed = 5f;
	[SerializeField] private float _minimalDistanceForAccelerated = 5f;
	[SerializeField] private float _speedChangeRotation = 10f;

	private CharacterMoving _character;
	private Rigidbody _rigidbody;

	private float _currentRotationSpeed;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Initialize(CharacterMoving character)
	{
		_character = character;
	}

	private void FixedUpdate()
	{
		ChangeDirection();
		
		ForwardMoving();
	}

	private void ChangeDirection()
	{
		Vector3 direction = _character.RigidbodyPosition - _rigidbody.position;
		direction.Normalize();

		float rotation = Vector3.Cross(direction, transform.up).z;

		float neededRotationSpeed = ChangeRotationSpeed();
		_currentRotationSpeed = Mathf.Lerp(_currentRotationSpeed, neededRotationSpeed, Time.fixedDeltaTime * _speedChangeRotation);

		Vector3 angularVelocity = Vector3.zero;
		angularVelocity.z = -rotation * _standartRotationSpeed;
		
		_rigidbody.angularVelocity = angularVelocity;
	}
	
	private void ForwardMoving()
	{
		_rigidbody.velocity = transform.up * _movingSpeed;
	}

	private float ChangeRotationSpeed()
	{
		float distance = Vector2.Distance(_character.RigidbodyPosition, _rigidbody.position);

		return distance < _minimalDistanceForAccelerated ? _standartRotationSpeed : _accetleratedRotationSpeed;
	}
}
