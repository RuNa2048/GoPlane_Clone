using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class MenuButton : MonoBehaviour
{
	private Button _button;

	protected virtual void Awake()
	{
		_button = GetComponent<Button>();
	}

	private void OnEnable()
	{
		_button.onClick.AddListener(Clicked);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(Clicked);
	}

	protected abstract void Clicked();
}
