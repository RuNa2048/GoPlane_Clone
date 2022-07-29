using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJoystick : ActivatingObject, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	[Header("References")]
	[SerializeField] private UIPlayerJoystick _uiJoystick;
	[SerializeField] private RectTransform _inputZone;

	public event Action<Vector2> OnInputChanged;
	
	private Vector2 _inputAxis = Vector2.zero;
	
	public override void Activate()
	{
		isDiactivate = false;
		
		_inputZone.gameObject.SetActive(true);
	}

	public override void Diactivate()
	{
		isDiactivate = true;
		
		_inputAxis = Vector2.zero;
		
		_uiJoystick.Diactivate();
		
		_inputZone.gameObject.SetActive(false);
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		if (isDiactivate)
			return;
		
		_uiJoystick.Activate(eventData.position);
		
		OnDrag(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isDiactivate)
			return;
		
		_inputAxis = _uiJoystick.CalculateInput(eventData.position);

		InputChanged();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (isDiactivate)
			return;
		
		_inputAxis = Vector2.zero;
		
		_uiJoystick.Diactivate();
	}

	private void InputChanged()
	{
		OnInputChanged?.Invoke(_inputAxis);
	}
}
