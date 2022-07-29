using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Image _standartImage;
	[SerializeField] private Image _reloadImage;
	[SerializeField] private Image _continueImage;

	[SerializeField] private GameModeLauncher _gameModeLauncher;
	
	private List<Image> _images;

	private void OnEnable()
	{
		_gameModeLauncher.OnStandartGameStarted += ChangeOnReload;
		_gameModeLauncher.OnModeStarted += ChangeOnContinue;
	}

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		_images = new List<Image>
		{
			_standartImage,
			_reloadImage,
			_continueImage
		};
	}

	private void HideAllImages()
	{
		foreach (var image in _images)
		{
			image.gameObject.SetActive(false);
		}
	}

	public void ChangeOnReload()
	{
		HideAllImages();
		
		_reloadImage.gameObject.SetActive(true);
	}
	
	public void ChangeOnContinue()
	{
		HideAllImages();
		
		_continueImage.gameObject.SetActive(true);
	}
}
