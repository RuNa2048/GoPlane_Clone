using System.Collections.Generic;
using UnityEngine;

public class ScorePopupSpawner : ActivatingObject
{
	[Header("Pool Settings")]
	[SerializeField] private ScorePopup _scorePopup;
	[SerializeField] private int _poolCount = 20;
	[SerializeField] private bool _isAutoExpand = false;

	[Header("Score Values")]
	[SerializeField] private int _characterScore = 2;
	[SerializeField] private int _rocketScore = 4;
	[SerializeField] private int _superpowerScore = 10;

	[Header("References")]
	[SerializeField] private ScoreCounter _scoreCounter;
	
	private PoolMono<ScorePopup> _scorePool;
	private List<Rocket> _rockets;
	
	private CharacterMoving _characterMoving;
	
	public void Initialize(CharacterMoving characterMoving, RocketDestrucktionZone rocketDestrucktionZone,List<Rocket> rockets)
	{
		_scorePool = new PoolMono<ScorePopup>(_scorePopup, _poolCount, transform);
		_scorePool.IsAutoExpand(_isAutoExpand);

		_rockets = rockets;
		
		_characterMoving = characterMoving;

		rocketDestrucktionZone.Contacted += SpawnSuperpowerScore;

		foreach (var rocket in _rockets)
		{
			rocket.OnHittedWithRocket += SpawnRocketScore;
		}
	}

	public override void Activate()
	{
		isDiactivate = false;
		
		_scoreCounter.Reset();
	}

	public override void Diactivate()
	{
		SpawnCharacterScore();
		
		isDiactivate = true;
	}

	private void SpawnCharacterScore()
	{
		if(isDiactivate)
			return;

		ScorePopup score = CreateScore(_characterMoving.transform.position);
		
		score.SetTextValue(_characterScore);
		
		_scoreCounter.Increase(_characterScore);
	}
	 
	private void SpawnRocketScore(Vector3 position)
	{
		ScorePopup score = CreateScore(position);
		
		score.SetTextValue(_rocketScore);
		
		if(isDiactivate)
			return;
		
		_scoreCounter.Increase(_rocketScore);
	}

	private void SpawnSuperpowerScore(Vector3 position)
	{
		ScorePopup scorePopup = CreateScore(position);
		
		scorePopup.SetTextValue(_superpowerScore);
		
		_scoreCounter.Increase(_superpowerScore);
	}

	private ScorePopup CreateScore(Vector3 position)
	{
		ScorePopup score = _scorePool.GetFreeElement();

		score.transform.position = position;

		return score;
	}
}