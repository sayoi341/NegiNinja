using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
  GameObject gameManager;
  Rigidbody rb;
  private bool flag = true;

  void Start()
  {
    gameManager = GameObject.Find("GameManager");
    rb = GetComponent<Rigidbody>();
    rb.AddForce(transform.up * 250);
    rb.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
  }

  public void Destory()
  {
    Destroy(gameObject);
  }

  public void Break()
  {

    if (flag)
    {
      gameManager.GetComponent<GameManager>().addScore(10);
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
