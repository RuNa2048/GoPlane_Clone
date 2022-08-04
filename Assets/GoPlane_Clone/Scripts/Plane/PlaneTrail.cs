using UnityEngine;

public class PlaneTrail : MonoBehaviour
{
	[SerializeField] private GameObject _standartTrail;
	[SerializeField] private GameObject _superPowerTrail;

	public void ActivateStandart()
	{
		_standartTrail.SetActive(true);	
		_superPowerTrail.SetActive(false);	
	}
	
	public void ActivateSuperPower()
	{
		_standartTrail.SetActive(false);	
		_superPowerTrail.SetActive(true);
	}
}