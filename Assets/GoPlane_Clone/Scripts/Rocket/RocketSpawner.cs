using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : ActivatingObject
{
    [Header("Rocket Settings")]
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private bool _isAutoExpand = false;
    [SerializeField] private int _poolCount = 30;
    
    [Header("Spawn Parameters")]
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private float _playerDistance = 40f;
    
    private PoolMono<Rocket> _rocketPool;
    
    public PoolMono<Rocket> RocketPool => _rocketPool;
    public List<Rocket> Rockets => _rocketPool.Pool;
    
    private GameActivator _gameActivator;
    private CharacterMoving _character;
    private Camera _mainCamera;
    
    private float _currentDelayMultiplier = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var rocket in Rockets)
            {
                rocket.gameObject.SetActive(false);
            }
        }
    }

    public void Initialize(CharacterMoving character, GameActivator gameActivator)
    {
        _gameActivator = gameActivator;
        
        _character = character;
        
        _mainCamera = Camera.main;

        _rocketPool = new PoolMono<Rocket>(_rocketPrefab, _poolCount, transform);
        _rocketPool.IsAutoExpand(_isAutoExpand);

        foreach (var rocket in _rocketPool.Pool)
        {
            rocket.Initialize(_character);
            
            _gameActivator.OnGameStarted += rocket.TurnOnHitWithPlayer;
            _gameActivator.OnGameWaited += rocket.TurnOffHitWithPlayer;
        }
    }

    private void OnDisable()
    {
        foreach (var rocket in _rocketPool.Pool)
        {
            _gameActivator.OnGameStarted -= rocket.TurnOnHitWithPlayer;
            _gameActivator.OnGameWaited -= rocket.TurnOffHitWithPlayer;
        }
    }

    public override void Activate()
    {
        isDiactivate = false;
        
        StartCoroutine(LaunchCreating());
    }

    public override void Diactivate()
    {
        isDiactivate = true;
        
       StopAllCoroutines();

       DisableActiveRockets();
    }

    private IEnumerator LaunchCreating()
    {
        yield return new WaitForSeconds(1.5f);
        
        while(!isDiactivate)
        {
            Spawn();

            yield return new WaitForSeconds(_spawnDelay);
            
            yield return null;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = CalculatePositionForSpawn();
        spawnPosition.z = 0f;

        Rocket rocket = _rocketPool.GetFreeElement();

        rocket.transform.position = spawnPosition;
    }

    private Vector3 CalculatePositionForSpawn()
    {
        Vector3 characterDirection = _character.transform.up;

        Vector3 spawnPosition = _character.RigidbodyPosition - characterDirection * _playerDistance;

        return spawnPosition;
    }

    private void DisableActiveRockets()
    {
        List<Rocket> activeRockets = _rocketPool.GetActivatedElements();

        foreach (var rocket in activeRockets)
        {
            rocket.gameObject.SetActive(false);
        }
    }
}
