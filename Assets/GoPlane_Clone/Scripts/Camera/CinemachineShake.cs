using System.Collections;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineShake : MonoBehaviour
{
	[Header("Shake Parametres")]
	[SerializeField] private float _duration = 0.6f;
	[SerializeField] private float _intensity = 0.6f;
	
	private CinemachineVirtualCamera _camera;
	private CinemachineBasicMultiChannelPerlin _perlinChannel;
	
	private void Awake()
	{
		_camera = GetComponent<CinemachineVirtualCamera>();

		_perlinChannel = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	}

	public void ShakeOnce()
	{
		StartCoroutine(Shake());
	}
	
	private IEnumerator Shake()
	{
		float currentDuration = _duration;

		_perlinChannel.m_AmplitudeGain = _intensity;

		while (currentDuration > 0)
		{
			currentDuration -= Time.deltaTime;

			yield return null;
		}
		
		_perlinChannel.m_AmplitudeGain = 0;
	}
}
