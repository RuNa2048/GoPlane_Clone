using UnityEngine;

public class MenuWindow : MonoBehaviour, IMenuWindow
{
	[SerializeField] private RectTransform[] _windowElements;

	private bool _isOpen = false;
	
	public void Open()
	{
		if (_isOpen)
			return;

		_isOpen = true;

		foreach (var element in _windowElements)
		{
			element.gameObject.SetActive(_isOpen);
		}
	}

	public void Close()
	{
		_isOpen = false;
		
		foreach (var element in _windowElements)
		{
			element.gameObject.SetActive(_isOpen);
		}
	}
}
