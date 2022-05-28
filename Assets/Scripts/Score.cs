using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    public ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter.ResetToZero();
    }

    private void Update()
    {
        textMeshPro.text = $"Score: {scoreCounter.Counter}";
    }

    private void OnDestroy()
    {
        Variables.ScoreCount = scoreCounter.Counter;
    }
}
