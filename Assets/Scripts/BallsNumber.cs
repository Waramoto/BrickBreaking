using TMPro;
using UnityEngine;

public class BallsNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    public BallsCounter ballsCounter;
    
    private void Update()
    {
        textMeshPro.text = $"{ballsCounter.Counter}x";
    }
}
