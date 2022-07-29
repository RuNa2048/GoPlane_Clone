using UnityEngine;

public class MiddleWindowChanger : MonoBehaviour
{
    [Header("Windows")]
    [SerializeField] private MenuWindow[] _middleWindows;

    [Header("Buttons")]
    [SerializeField] private OpenWindowButton[] _buttons;

    [Header("References")]
    [SerializeField] private GameActivator _gameActivator;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.OnClicked += Change;
        }

        _gameActivator.OnGameWaited += CloseAllWindows;
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.OnClicked -= Change;
        }
        
        _gameActivator.OnGameWaited -= CloseAllWindows;
    }

    private void Change(MenuWindow neededWindow)
    {
        foreach (var window in _middleWindows)
        {
            if(window == neededWindow)
            {
                window.Open();
                
                continue;
            }
            
            window.Close();
        }
    }

    private void CloseAllWindows()
    {
        foreach (var window in _middleWindows)
        {
            window.Close();
        }
    }
}
