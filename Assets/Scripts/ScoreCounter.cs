using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Counter { get; private set; } = 0;

    public void IncreaseByOne()
    {
        Counter++;
    }

    public void ResetToZero()
    {
        Counter = 0;
    }
}
