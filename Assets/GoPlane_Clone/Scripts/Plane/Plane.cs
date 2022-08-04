using UnityEngine;

public class Plane : MonoBehaviour
{
	[SerializeField] private PlaneTrail _planeTrail;

	[SerializeField] private SuperpowerModule _superpowerModule;

	private void OnEnable()
	{
		_superpowerModule.EffectStarted += _planeTrail.ActivateSuperPower;
		_superpowerModule.EffectEnded += _planeTrail.ActivateStandart;
	}
	
	private void OnDisable()
	{
		_superpowerModule.EffectStarted += _planeTrail.ActivateSuperPower;
		_superpowerModule.EffectEnded += _planeTrail.ActivateStandart;
	}
}

