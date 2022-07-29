using UnityEngine;

public class StandartGameMode : GameMode
{
	[Header("References")]
	[SerializeField] private CoinModule _coinModule;
	[SerializeField] private RocketModule _rocketModule;
	[SerializeField] private ScoreModule _scoreModule;
	[SerializeField] private SuperpowerModule _superpowerModule;

	public override void Initialize(GameActivator gameActivator)
	{
		this.gameActivator = gameActivator;
	}

	public override void Activate()
	{
		gameActivator.OnGameStarted += _coinModule.Activate;
		gameActivator.OnGameStarted += _rocketModule.Activate;
		gameActivator.OnGameStarted += _scoreModule.Activate;
		gameActivator.OnGameStarted += _superpowerModule.Activate;

		gameActivator.OnGameWaited += _coinModule.Diactivate;
		gameActivator.OnGameWaited += _scoreModule.Diactivate;
		gameActivator.OnGameWaited += _superpowerModule.Diactivate;

		gameActivator.OnGameEnded += _rocketModule.Diactivate;
	}

	public override void Diactivate()
	{
		gameActivator.OnGameStarted -= _coinModule.Activate;
		gameActivator.OnGameStarted -= _rocketModule.Activate;
		gameActivator.OnGameStarted -= _scoreModule.Activate;

		gameActivator.OnGameWaited -= _coinModule.Diactivate;
		gameActivator.OnGameWaited -= _scoreModule.Diactivate;
		gameActivator.OnGameWaited -= _superpowerModule.Diactivate;

		gameActivator.OnGameEnded -= _rocketModule.Diactivate;
	}
}
