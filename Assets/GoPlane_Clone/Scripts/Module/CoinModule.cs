using System.Collections.Generic;
using UnityEngine;

public class CoinModule : GameModule
{
	[Header("Coin Components")]
	[SerializeField] private CoinCounter _coinCounter;
	[SerializeField] private CoinSpawner _coinSpawner;
	[SerializeField] private RocketDestrucktionZone _rocketDestrucktionZone;

	public void Initialize(List<Rocket> rockets)
	{
		_coinSpawner.Initialize(_rocketDestrucktionZone, rockets);
		_coinCounter.Initialize(_coinSpawner.Coins);
	}

	public override void Activate()
	{
		_coinSpawner.Activate();
	}

	public override void Diactivate()
	{
		_coinSpawner.Diactivate();
	}
}

