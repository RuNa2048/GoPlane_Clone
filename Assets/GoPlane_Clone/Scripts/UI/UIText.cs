using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIText : MonoBehaviour
{ 
	protected TextMeshProUGUI text;

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	public void Change(int newAmount)
	{
		text.text = newAmount.ToString();
	}
	
	public void Change(string newText)
	{
		text.text = newText;
	}
}
