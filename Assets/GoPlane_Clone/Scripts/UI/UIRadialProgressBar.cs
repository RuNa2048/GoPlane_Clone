using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIRadialProgressBar : MonoBehaviour
{
	private Image _fillImage;
	
	private void Awake()
	{
		_fillImage = GetComponent<Image>();
	}
	
	public void Reset()
	{
		_fillImage.fillAmount = 0;
	}

	public void Change(float fill)
	{
		_fillImage.fillAmount = fill;
	}
}

