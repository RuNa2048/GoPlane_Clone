using UnityEngine;

public abstract class ActivatingObject: MonoBehaviour
{
	protected bool isDiactivate = true;
	
	public abstract void Activate();
	public abstract void Diactivate();
}