using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 _mousePos;
    
    [SerializeField] private LayerMask floor;
    [SerializeField] private BallsCounter ballsCounter;
    [SerializeField] private GlobalCounter globalCounter;
    [SerializeField] private GameIteration gameIteration;

    public float speed;
    
    private void Start()
    {
        ballsCounter.Counter--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.gameObject.layer == floor.value)
        {
            ballsCounter.Counter++;
            if (ballsCounter.Counter == globalCounter.Counter)
            {
                ballsCounter.Counter++;
                globalCounter.IncreaseByOne();
                gameIteration.InProcess = false;
            }
            Destroy(gameObject);
        }
    }
}
