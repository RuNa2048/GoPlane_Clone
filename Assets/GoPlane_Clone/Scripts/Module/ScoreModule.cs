using System.Collections.Generic;
using UnityEngine;

public class ScoreModule : GameModule
{
	[Header("References")]
	[SerializeField] private ScorePopupSpawner _scoreSpawner;
	[SerializeField] private RocketDestrucktionZone _rocketDestrucktionZone;

	public void Initialize(CharacterMoving characterMoving, List<Rocket> rockets)
	{
		_scoreSpawner.Initialize(characterMoving, _rocketDestrucktionZone, rockets);
	}
	
	public override void Activate()
	{
		_scoreSpawner.Activate();
	}

	public override void Diactivate()
	{
		_scoreSpawner.Diactivate();
	}
}