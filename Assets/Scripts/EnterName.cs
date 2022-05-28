using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    public void AddNameToRating()
    {
        Variables.Rating.Add(textMeshPro.text, Variables.ScoreCount);

        using (var sw = new StreamWriter("rating.txt", true))
        {
            sw.WriteLine($"{textMeshPro.text}, {Variables.ScoreCount}");
        }
        
        Variables.UpdateRating();

        SceneManager.LoadScene("GameOverScene");
    }
}
