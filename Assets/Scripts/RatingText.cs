using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class RatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    
    private void Start()
    {
        Variables.UpdateRating();
        var i = 0;
        foreach (var r in Variables.Rating)
        {
            textMeshPro.text += $"{r.Key} - {r.Value}\n";
            i++;
            if (i == 5)
            {
                break;
            }
        }
    }
}
