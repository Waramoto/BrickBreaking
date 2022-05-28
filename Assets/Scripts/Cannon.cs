using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    private Vector3 _mousePos;
    private Vector2 _direction;
    private float _angle;

    [SerializeField] private GameObject trajectory;
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject startBall;
    [SerializeField] private GlobalCounter globalCounter;
    [SerializeField] private BallsCounter ballsCounter;
    [SerializeField] private GameIteration gameIteration;
    [SerializeField] private Button ballsReturnButton;

    private void Awake()
    {
        globalCounter.ResetToOne();
    }

    private void Start()
    {
        trajectory.SetActive(false);
        ballsCounter.Counter = globalCounter.Counter;
    }

    private void Update()
    {
        if (ballsCounter.Counter == globalCounter.Counter)
        {
            startBall.SetActive(true);

            if (Camera.main != null)
            {
                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            _direction = (_mousePos - transform.position).normalized;
            _angle = Vector2.SignedAngle(Vector2.up, _direction);

            if (Input.GetMouseButton(0))
            {
                if (_angle < -75f || _angle > 75f)
                {
                    trajectory.SetActive(false);
                }
                else
                {
                    startBall.SetActive(true);
                    trajectory.SetActive(true);
                    trajectory.transform.eulerAngles = new Vector3(0, 0, _angle);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                trajectory.SetActive(false);
                if (!(_angle < -75f || _angle > 75f))
                {
                    StartCoroutine(ShootBall());
                    StartCoroutine(ActiveReturnButton());
                }
            }
        }
    }

    private IEnumerator ShootBall()
    {
        startBall.SetActive(false);
        for (var i = 0; i < globalCounter.Counter; i++)
        {
            yield return new WaitForSeconds(0.08f);
            var go = gameObject;
            var o = Instantiate(ball, go.transform.position, Quaternion.identity, go.transform);
            o.GetComponent<Rigidbody2D>().AddForce(_direction.normalized * ball.speed, ForceMode2D.Impulse);
        }
    }

    private IEnumerator ActiveReturnButton()
    {
        yield return new WaitForSeconds(3f);
        ballsReturnButton.gameObject.SetActive(ballsCounter.Counter != globalCounter.Counter);
    }
    
    public void ReturnBalls()
    {
        var balls = FindObjectsOfType<Ball>();

        foreach (var b in balls)
        {
            Destroy(b.gameObject);
        }

        globalCounter.IncreaseByOne();
        ballsCounter.Counter = globalCounter.Counter;
        gameIteration.InProcess = false;
        ballsReturnButton.gameObject.SetActive(false);
    }
}
