using UnityEngine;

public class Character : MonoBehaviour
{
	public void Activate()
	{
		gameObject.SetActive(true);
	}

	public void Diactivate()
	{
		gameObject.SetActive(false);
	}
}
