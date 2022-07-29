using System.Collections;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraSize : MonoBehaviour
{
	[Header("Size Parameters")]
	[SerializeField] private int _standartSize = 45;
	[SerializeField] private int _maxSize = 55;

	[Header("Changing Parameters")]
	[SerializeField] private float _speed = 10f;

	private CinemachineVirtualCamera _camera;

	private void Awake()
	{
		_camera = GetComponent<CinemachineVirtualCamera>();
	}

	public void Increase()
	{
		StartCoroutine(ChangeOnMaximumSize());
	}

	public void Decrease()
	{
		StartCoroutine(ChangeOnStandartSize());
	}
	
	private IEnumerator ChangeOnMaximumSize()
	{
		float currentSize = _camera.m_Lens.OrthographicSize;

		while (currentSize < _maxSize)
		{
			Change(ref currentSize, _maxSize);
			
			yield return null;
		}
	}

	private IEnumerator ChangeOnStandartSize()
	{
		float currentSize = _camera.m_Lens.OrthographicSize;

		while (currentSize > _standartSize)
		{
			Change(ref currentSize, _standartSize);

			yield return null;
		}
	}

	private void Change(ref float currentSize, float neededSize)
	{
		currentSize = Mathf.MoveTowards(currentSize, neededSize, Time.deltaTime * _speed);

		_camera.m_Lens.OrthographicSize = currentSize;
	}
}
