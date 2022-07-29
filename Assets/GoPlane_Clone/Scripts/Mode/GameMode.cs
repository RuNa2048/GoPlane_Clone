using UnityEngine;

public abstract class GameMode : MonoBehaviour, IGameMode
{
	[SerializeField] private GameModeType _gameModeType;
	public GameModeType Type => _gameModeType;

	protected GameActivator gameActivator;
	
	public abstract void Initialize(GameActivator gameActivator);

	public abstract void Activate();

	public abstract void Diactivate();
}
