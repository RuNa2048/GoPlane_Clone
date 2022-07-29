using UnityEngine;

public class GameSystem : MonoBehaviour
{
	[SerializeField] private CharacterInitializer _characterInitializer; 
	[SerializeField] private CinemachineShake _cinemachineShake;
	[SerializeField] private GameplaySpeed _gameplaySpeed;
	[SerializeField] private Vibration _vibration;
	[SerializeField] private GameActivator _gameActivator;


	[SerializeField] private GameModeLauncher _gameModeLauncher;
	[SerializeField] private ModuleInitializer _moduleInitializer;
	
	private void OnEnable()
	{
		_gameActivator.OnGameWaited += _gameplaySpeed.Slowdown;
		
		_gameActivator.OnGameEnded += _vibration.Vibrate;
		_gameActivator.OnGameEnded += _gameplaySpeed.SetNormalSpeed;
		_gameActivator.OnGameEnded += _cinemachineShake.ShakeOnce;
	}

	private void Start()
	{
		_characterInitializer.Initialize();
		_gameModeLauncher.Initialize(_gameActivator);
		_moduleInitializer.Initialize(_characterInitializer.CharacterMoving, _gameActivator);
	}
}
