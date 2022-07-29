using UnityEngine;

public class CharacterInitializer : MonoBehaviour
{
    [Header("Initializing Components")]
    //[SerializeField] private CameraMoving _camera;
    [SerializeField] private CharacterMoving _characterMoving;
    [SerializeField] private PlayerJoystick _joystick;
    
    [Header("References")]
    [SerializeField] private GameActivator _gameActivator;
    [SerializeField] private ActivatingObject[] _activatableObjects;

    public CharacterMoving CharacterMoving => _characterMoving;
    
    private Character _character;
    
    private void Awake()
    {
        _character = _characterMoving.GetComponent<Character>();
    }

    public void Initialize()
    {
        //_camera.Initialize(_characterMoving);

        foreach (var activatableObject in _activatableObjects)
        {
            _gameActivator.OnGameStarted += activatableObject.Activate;
            _gameActivator.OnGameEnded += activatableObject.Diactivate;
        }

        _gameActivator.OnGameWaited += _joystick.Diactivate;

        _joystick.OnInputChanged += _characterMoving.Rotate;
        _joystick.Diactivate();
        
        _gameActivator.OnGameStarted += _character.Activate;
        _gameActivator.OnGameEnded += _character.Diactivate;
    }

    private void OnDisable()
    {
        foreach (var activatableObject in _activatableObjects)
        {
            _gameActivator.OnGameStarted -= activatableObject.Activate;
            _gameActivator.OnGameEnded -= activatableObject.Diactivate;
        }
        
        _gameActivator.OnGameWaited -= _joystick.Diactivate;

        _joystick.OnInputChanged -= _characterMoving.Rotate;

        _gameActivator.OnGameStarted -= _character.Activate;
        _gameActivator.OnGameEnded -= _character.Diactivate;
    }
}
