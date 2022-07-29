using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenuWindow : MonoBehaviour
{
	[Header("Elements For Animation")]
	[SerializeField] private Image _backgroundImage;
	[SerializeField] private RectTransform[] _movingButtons;
	
	[Header("Color Settings")]
	[SerializeField] private Color _standartColor= Color.clear;
	[SerializeField] private Color _openColor = new Color(9f, 5f, 31f, 150f);
	[SerializeField] private float _changeOpenColorDuration = 1f;
	[SerializeField] private float _changeStandartColorDuration = 0.4f;

	[Header("Moving Parameters")]
	[SerializeField] private RectTransform _startTransform;
	[SerializeField] private float _heightOfsset = 220f;
	[SerializeField] private float _movingOpenDuration = 1f;
	[SerializeField] private float _movingStandartDuration = 0.4f;

	private List<Tween> _tweens = new List<Tween>();

	private bool _isOpen = false;

	private void Start()
	{
		_backgroundImage.gameObject.SetActive(false);
	}

	public void Change()
	{
		foreach (var tween in _tweens)
		{
			tween.Complete();
		}

		_tweens.Clear();
		
		Color currentColor = _openColor;
		float currentColorDuration = _changeOpenColorDuration;

		if (_isOpen)
		{ 
			currentColor = _standartColor;
			currentColorDuration = _changeStandartColorDuration;
		}
		
		Tween colorTween = _backgroundImage.DOColor(currentColor, currentColorDuration).SetEase(Ease.Linear);
		
		_tweens.Add(colorTween);
		
		ChangeButtonsPosition();

		_isOpen = !_isOpen;
		
		_backgroundImage.gameObject.SetActive(_isOpen);
	}

	private void ChangeButtonsPosition()
	{
		Vector2 endPosition = _startTransform.anchoredPosition;
		float currentMovingDuration = _movingStandartDuration;

		foreach (var button in _movingButtons)
		{
			if (!_isOpen)
			{
				button.anchoredPosition = _startTransform.anchoredPosition;

				endPosition.y += _heightOfsset;

				currentMovingDuration = _movingOpenDuration;
			}

			Tween tween = button.DOAnchorPos(endPosition, currentMovingDuration).SetEase(Ease.Flash);
			
			_tweens.Add(tween);
		}
	}
}
