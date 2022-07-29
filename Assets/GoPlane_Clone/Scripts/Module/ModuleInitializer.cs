using UnityEngine;

public class ModuleInitializer : MonoBehaviour
{
	[Header("Modules")]
	[SerializeField] private CoinModule _coinModule;
	[SerializeField] private RocketModule _rocketModule;
	[SerializeField] private ScoreModule _scoreModule;
	[SerializeField] private SuperpowerModule _superpowerModule;

	public void Initialize(CharacterMoving characterMoving, GameActivator gameActivator)
	{
		_rocketModule.Initialize(characterMoving, gameActivator);
		_coinModule.Initialize(_rocketModule.Rockets);
		_scoreModule.Initialize(characterMoving, _rocketModule.Rockets);
		_superpowerModule.Initialize(_rocketModule.RocketPool);
	}
}