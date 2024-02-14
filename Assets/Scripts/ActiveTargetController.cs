using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTargetController : MonoBehaviour
{

  public GameObject parent;

  void Update()
  {
    if (parent == null)
    {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Field")
    {
      parent.GetComponent<TargetController>().Destory();
    }

    if (other.gameObject.tag == "Player")
    {
      parent.GetComponent<TargetController>().Break();
      Destroy(gameObject);
    }
  }
}
