using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TextMeshPro))]
public class ScorePopup : MonoBehaviour
{
	[Header("Timings")]
	[SerializeField] private float _lifeDuration;

	[Header("Moving")]
	[SerializeField] private float _movingSpeed = 30f;
	
	private TextMeshPro _textMesh;

	private void Awake()
	{
		_textMesh = GetComponent<TextMeshPro>();
	}

	public void SetTextValue(int score)
	{
		_textMesh.text = score.ToString();

		StartCoroutine(LifeTimeCounting());
	}

	private IEnumerator LifeTimeCounting()
	{
		float currentDuration = 0f;

		while (currentDuration < _lifeDuration)
		{
			currentDuration += Time.deltaTime;

			UpMoving();
			
			yield return null;
		}
		
		gameObject.SetActive(false);
	}

	private void UpMoving()
	{
		transform.position += Vector3.up * Time.deltaTime * _movingSpeed;
	}
}