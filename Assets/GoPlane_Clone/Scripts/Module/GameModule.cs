using UnityEngine;

public abstract class GameModule : MonoBehaviour, IGameModule
{
	public abstract void Activate();

	public abstract void Diactivate();
}