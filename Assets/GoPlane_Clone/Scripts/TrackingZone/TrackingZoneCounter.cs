using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class TrackingZoneCounter : MonoBehaviour
{
	[SerializeField] private UIRadialProgressBar _radialProgressBar;
	[SerializeField] private Image _zoneBackground;
	
	public event Action Charged;  
	public event Action Discharged;
	
	private float _currentDuration;
	private float _maximumtDuration;
	private bool _isCharged = false;

	public void Initialize(float maximumDuration)
	{
		_maximumtDuration = maximumDuration;
	}

	public void LaunchIncrease()
	{
		if (_isCharged)
			return;
		
		StopAllCoroutines();

		StartCoroutine(Increase());
	}
	
	private IEnumerator Increase()
	{
		_zoneBackground.gameObject.SetActive(true);
		
		while (_currentDuration < _maximumtDuration)
		{
			float deltaTime = Time.deltaTime;
			
			_currentDuration += deltaTime;

			ChangeProgress();
			
			yield return null;
		}
		
		OnCharged();
	}

	private void OnCharged()
	{
		Charged?.Invoke();
		
		LaunchDecrease();
		
		_isCharged = true;
	}
	
	public void LaunchDecrease()
	{
		if (_isCharged)
			return;
		
		StopAllCoroutines();

		StartCoroutine(Decrease());
	}
	
	private IEnumerator Decrease()
	{
		while (_currentDuration > 0f)
		{
			float deltaTime = Time.deltaTime;

			_currentDuration -= deltaTime;
			
			ChangeProgress();

			yield return null;
		}

		_zoneBackground.gameObject.SetActive(false);

		if (_isCharged)
		{
			OnDischarged();
		}
	}

	private void OnDischarged()
	{
		_isCharged = false;

		Discharged?.Invoke();
	}

	private void ChangeProgress()
	{
		float fill = _currentDuration / _maximumtDuration;

		_radialProgressBar.Change(fill);
	}

	public void Stop()
	{
		StopAllCoroutines();

		_currentDuration = 0;

		_isCharged = false;
		
		_radialProgressBar.Reset();
		
		_zoneBackground.gameObject.SetActive(false);
	}
}