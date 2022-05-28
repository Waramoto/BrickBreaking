using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : Target
{
    [SerializeField] private TextMeshProUGUI staminaCounter;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private GlobalCounter globalCounter;
    
    private void Start()
    {
        Stamina = globalCounter.Counter;
    }

    private new void Update()
    {
        staminaCounter.text = $"{Stamina}";
        if (gameObject.transform.position.y <= -3.75f)
        {
            SceneManager.LoadScene("EnterNameScene");
        }
    }

    public override void Disappear()
    {
        scoreCounter.IncreaseByOne();
        base.Disappear();
    }
}