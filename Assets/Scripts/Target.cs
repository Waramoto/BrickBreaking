using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField] protected LayerMask ball;

    protected int Stamina { get; set; } = 1;

    public bool IsDestroyed { get; set; }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.gameObject.layer == ball.value)
        {
            Stamina--;
            if (Stamina == 0)
            {
                Disappear();
            }
        }
    }

    protected void Update()
    {
        if (gameObject.transform.position.y <= -3.75f)
        {
            SceneManager.LoadScene("EnterNameScene");
        }
    }

    public virtual void Disappear()
    {
        IsDestroyed = true;
        Destroy(gameObject);
    }
}