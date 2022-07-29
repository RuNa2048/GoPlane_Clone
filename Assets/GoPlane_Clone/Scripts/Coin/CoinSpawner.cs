using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ActivatingObject
{
	[Header("Pool Settings")]
	[SerializeField] private Coin _coinPrefab;
	[SerializeField] private bool _isAutoExpand = false;
	[SerializeField] private int _poolCount = 100;
	
	[Header("Spawn Settings")]
	[SerializeField] private int _minAmountInCircle = 6;
	[SerializeField] private int _maxAmountInCircle = 12;
	[SerializeField] private float _circleRadius = 5f;

	public List<Coin> Coins => _coinsPool.Pool;
	
	private PoolMono<Coin> _coinsPool;
	private List<Rocket> _rockets;
	
	public void Initialize(RocketDestrucktionZone rocketDestrucktionZone, List<Rocket> rockets)
	{
		_rockets = rockets;
		
		_coinsPool = new PoolMono<Coin>(_coinPrefab, _poolCount, transform);
		_coinsPool.IsAutoExpand(_isAutoExpand);

		rocketDestrucktionZone.Contacted += SpawnMultipleInCircle;
		
		foreach (var rocket in _rockets)
		{
			rocket.OnHittedWithRocket += Spawn;
		}
	}
	
	private void OnDisable()
	{
		foreach (var rocket in _rockets)		
		{
			rocket.OnHittedWithRocket -= Spawn;
		}
	}
	
	public override void Activate()
	{
		isDiactivate = false;
	}

	public override void Diactivate()
	{
		DisableActiveCoins();
		
		isDiactivate = true;
	}
	
	private void Spawn(Vector3 position)
	{
		if (isDiactivate)
			return;
		
		Coin coin = _coinsPool.GetFreeElement();

		coin.transform.position = position;
	}

	public void SpawnMultipleInCircle(Vector3 spawnPoint)
	{
		int amount = Random.Range(_minAmountInCircle, _maxAmountInCircle + 1);
		
		for (int i = 0; i < amount; i++)
		{
			Vector3 position = Random.insideUnitCircle * _circleRadius;

			position += spawnPoint;

			Spawn(position);
		}
	}

	private void DisableActiveCoins()
	{
		List<Coin> coins = _coinsPool.GetActivatedElements();

		foreach (var coin in coins)
		{
			coin.gameObject.SetActive(false);
		}
	}
}
