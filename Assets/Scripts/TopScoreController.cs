using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopScoreController : MonoBehaviour
{
    public List<int> topScores;
    public TextMeshProUGUI topScoreText;

    void Start()
    {
        topScores = new List<int>();
        topScoreText.text = "TOP\nScore\n";
    }

    public void addScore(int score)
    {
        topScores.Add(score);
        topScores.Sort();
        topScores.Reverse();
        if (topScores.Count > 5)
        {
            topScores.RemoveAt(5);
        }
        topScoreText.text = "TOP\nScore\n";
        for (int i = 0; i < topScores.Count; i++)
        {
            topScoreText.text += i + 1 + ". " + topScores[i] + "\n";
        }
    }
}
