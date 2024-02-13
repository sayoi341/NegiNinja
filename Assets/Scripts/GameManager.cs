using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

  public int score;
  public List<int> scoreList;

  public TextMeshProUGUI scoreText;

  void Start()
  {
    score = 0;
    scoreList = new List<int>();
    scoreText.text = "Score: " + score;
  }

  void Update()
  {
  }

  public void addScore(int s)
  {
    this.score += s;
    scoreText.text = "Score: " + this.score;
  }

  public void startGame()
  {
    score = 0;
    scoreText.text = "Score: " + score;
  }

  void endGame()
  {
    scoreList.Add(score);
    score = 0;
  }
}
