using System;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private PlayerMoving _player;
    [SerializeField] private float _speed = 10f;

    private float _startZPosition;

    private void Start()
    {
        _startZPosition = transform.position.z;
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 newPosition = _player.transform.position;
        newPosition.z = _startZPosition;
        
        
        
        transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
