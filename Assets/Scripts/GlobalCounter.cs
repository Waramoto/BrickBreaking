using UnityEngine;

public class GlobalCounter : MonoBehaviour
{
    public int Counter { get; private set; } = 1;

    public void IncreaseByOne()
    {
        Counter++;
    }

    public void ResetToOne()
    {
        Counter = 1;
    }
}
