using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetController : MonoBehaviour
{
  GameObject gameManager;
  Rigidbody rb;
  private bool flag = true;
  public int score = 0;

  void Start()
  {
    gameManager = GameObject.Find("GameManager");
    rb = GetComponent<Rigidbody>();
    rb.AddForce(transform.up * 250);
    rb.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
  }

  void Update()
  {
    if (!gameManager.GetComponent<GameManager>().isGameActive)
    {
      Destroy(gameObject);
    }
  }

  public void Destory()
  {
    Destroy(gameObject);
  }

  public void Break()
  {

    if (flag)
    {
      gameManager.GetComponent<GameManager>().addScore(score);
      flag = false;
    }
    rb.useGravity = false;
    GameObject brokenTarget = transform.GetChild(1).gameObject;
    brokenTarget.SetActive(true);
    foreach (Transform gct in brokenTarget.transform)
    {
      gct.gameObject.SetActive(true);
    }
    Invoke("Destory", 2f);
  }
}
