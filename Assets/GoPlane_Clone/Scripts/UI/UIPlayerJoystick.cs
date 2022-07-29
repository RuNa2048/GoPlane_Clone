using UnityEngine;

public class UIPlayerJoystick : MonoBehaviour
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;
    
    [SerializeField] private float _handleRange = 1;

    private RectTransform _baseRect;
    private Camera _mainCamera;

    private void Awake()
    {
        _baseRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;

        Centralize();
        Diactivate();
    }

    private void Centralize()
    {
        Vector2 center = new Vector2(0.5f, 0.5f);

        _background.pivot = center;

        _handle.anchorMin = center;
        _handle.anchorMax = center;
        _handle.pivot = center;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void Activate(Vector2 position)
    {
        _background.anchoredPosition = ScreenPointToAnchoredPosition(position);

        _background.gameObject.SetActive(true);
    }
    
    public void Diactivate()
    {
        _handle.anchoredPosition = Vector2.zero;
        
        _background.gameObject.SetActive(false);
    }
    
    private Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint = Vector2.zero;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _mainCamera, out localPoint))
        {
            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            
            return localPoint - (_background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }
        
        return Vector2.zero;
    }

    public Vector2 CalculateInput(Vector2 pointerPosition)
    {
        Vector2 backgroundPosition = RectTransformUtility.WorldToScreenPoint(_mainCamera, _background.position);
        Vector2 radius = _background.sizeDelta / 2;
        Vector2 input = Vector2.zero;

        input = (pointerPosition - backgroundPosition) / radius;

        if (input.magnitude > 1)
        {
            input.Normalize();
        }

        _handle.anchoredPosition = input * radius * _handleRange;

        return input;
    }
}
