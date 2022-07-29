using System;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class AnimatedMenuButton : MenuButton
{
	[Header("Rotation")]
	[SerializeField] private RectTransform _rotationImage;
	[SerializeField] private Vector3 _startRotation = Vector3.zero;
	[SerializeField] private Vector3 _endRotation = new Vector3(0f, 0f , 180f);
	[SerializeField] private float _durationStartRotation = 0.4f;
	[SerializeField] private float _durationEndRotation = 1f;
	
	public event Action OnClicked;
	
	[CanBeNull]
	private Tween _rotateTween;
	
	private bool _isOpen = false;

	protected override void Clicked()
	{
		_rotateTween!.Complete();
		
		Vector3 currentRotation;
		float currentDurationn;

		if (_isOpen)
		{
			currentRotation = _startRotation;
			currentDurationn = _durationStartRotation;
		}
		else
		{
			currentRotation = _endRotation;
			currentDurationn = _durationEndRotation;
		}
		
		_isOpen = !_isOpen;

		Tween tween = _rotationImage.DORotate(currentRotation, currentDurationn);

		_rotateTween = tween;
		
		OnClicked?.Invoke();
	}
}
