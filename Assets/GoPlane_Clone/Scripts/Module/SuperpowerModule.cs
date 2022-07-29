using System;
using UnityEngine;

public class SuperpowerModule : GameModule
{
	[Header("Timings")]
	[SerializeField] private float _effectDuration = 3f;
	
	[Header("Tracking")]
	[SerializeField] private RocketTrackingZone _rocketTracking;
	[SerializeField] private TrackingZoneCounter _trackingZoneCounter;

	[Header("Additional Components")]
	[SerializeField] private CameraSize _cameraSize;
	[SerializeField] private RocketDestrucktionZone _rocketDestrucktionZone;
	[SerializeField] private Vibration _vibration;
	[SerializeField] private CinemachineShake _cinemachineShake;
	
	public event Action EffectStarted; 
	public event Action EffectEnded;

	private PoolMono<Rocket> _rocketPool;
 
	public void Initialize(PoolMono<Rocket> rocketPool)
	{
		_trackingZoneCounter.Initialize(_effectDuration);

		_rocketPool = rocketPool;
	}
	
	public override void Activate()
	{
		_rocketTracking.Activate();
		
		_rocketTracking.OnHasEntered += _trackingZoneCounter.LaunchIncrease;
		_rocketTracking.OnCameOut += _trackingZoneCounter.LaunchDecrease;

		_trackingZoneCounter.Charged += OnEffectStarted;
		_trackingZoneCounter.Charged += _rocketTracking.Diactivate;
		
		_trackingZoneCounter.Discharged += OnEffectEnded;
		_trackingZoneCounter.Discharged += _rocketTracking.Activate;
	}

	public override void Diactivate()
	{
		_rocketTracking.Diactivate();

		_trackingZoneCounter.Stop();

		OnEffectEnded();
		
		_rocketTracking.OnHasEntered -= _trackingZoneCounter.LaunchIncrease;
		_rocketTracking.OnCameOut -= _trackingZoneCounter.LaunchDecrease;
		
		_trackingZoneCounter.Charged -= OnEffectStarted;
		_trackingZoneCounter.Discharged -= OnEffectEnded;
	}

	private void OnEffectStarted()
	{
		EffectStarted?.Invoke();
				
		_cameraSize.Increase();
		
		_rocketDestrucktionZone.Activate();
		
		_vibration.Vibrate();
		
		_cinemachineShake.ShakeOnce(); 
	}
	
	private void OnEffectEnded()
	{
		EffectEnded?.Invoke();
		
		_cameraSize.Decrease();

		foreach (var rocket in _rocketPool.GetActivatedElements())
		{
			rocket.gameObject.SetActive(false);
		}
		
		_rocketDestrucktionZone.Diactivate();
	}
}