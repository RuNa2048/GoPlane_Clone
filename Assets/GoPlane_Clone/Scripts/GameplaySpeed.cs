using UnityEngine;

public class GameplaySpeed : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float _normalTimeScale = 1;
    [SerializeField] private float _slowdownTimeScale = 0.5f;

    public void Slowdown()
    {
        Time.timeScale = _slowdownTimeScale;
    }

    public void SetNormalSpeed()
    {
        Time.timeScale = _normalTimeScale;
    }
}
