using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

  int score;

  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI timerText;

  public Button startButton;
  public GameObject Pointer;
  public GameObject TargetGenerator;

  public TopScoreController topScoreController;

  public bool isGameActive = false;
  private float time = 0.0f;
  private float oldTime = 0.0f;
  private float timeLimit = 60.0f;

  void Start()
  {
    score = 0;
    scoreText.text = "Score: " + score;
    startButton.onClick.AddListener(startGame);
    startButton.gameObject.SetActive(true);
    Pointer.SetActive(true);
    TargetGenerator.SetActive(false);
  }

  void Update()
  {
    if (isGameActive)
    {
      time += Time.deltaTime;
      if (time - oldTime > 1.0f)
      {
        oldTime = time;
        timeLimit -= 1.0f;
      }
      if (timeLimit <= 10.0f)
      {
        TargetGenerator.GetComponent<TargetGenerator>().span = 0.2f;
      }
      if (timeLimit <= 0.0f)
      {
        isGameActive = false;
        endGame();
      }
    }
    timerText.text = "Time: " + timeLimit;
  }

  public void addScore(int s)
  {
    this.score += s;
    scoreText.text = "Score: " + this.score;
  }

  public void startGame()
  {
    startButton.gameObject.SetActive(false);
    Pointer.SetActive(false);
    TargetGenerator.SetActive(true);

    score = 0;
    scoreText.text = "Score: " + score;
    isGameActive = true;

    time = 0.0f;
    oldTime = 0.0f;
    timeLimit = 60.0f;
  }

  void endGame()
  {
    startButton.gameObject.SetActive(true);
    Pointer.SetActive(true);
    TargetGenerator.SetActive(false);

    topScoreController.addScore(score);
  }
}
