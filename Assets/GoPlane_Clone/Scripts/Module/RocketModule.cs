using System.Collections.Generic;
using UnityEngine;

public class RocketModule : GameModule
{
	[SerializeField] private RocketSpawner _rocketSpawner;

	public List<Rocket> Rockets => _rocketSpawner.Rockets;
	public PoolMono<Rocket> RocketPool => _rocketSpawner.RocketPool;

	private CharacterMoving _characterMoving;
	private GameActivator _gameActivator;

	public void Initialize(CharacterMoving characterMoving, GameActivator gameActivator)
	{
		_characterMoving = characterMoving;
		_gameActivator = gameActivator;
		
		_rocketSpawner.Initialize(_characterMoving, _gameActivator);
		
		foreach (var rocket in Rockets)
		{
			rocket.OnHittedWithCharacter += _gameActivator.GameWaited;
		}
	}
	
	public override void Activate()
	{
		_rocketSpawner.Activate();
	}

	public override void Diactivate()
	{
		_rocketSpawner.Diactivate();
	}
}