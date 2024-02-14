using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
  public GameObject[] prefabs;
  public float span = 0.5f;
  float delta = 0;

  void Update()
  {
    this.delta += Time.deltaTime;
    if (this.delta > this.span)
    {
      this.delta = 0;
      GameObject go = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)]) as GameObject;
      float theta = UnityEngine.Random.Range(30, 150) * (float)Math.PI / 180.0f;
      float px = (float)Math.Cos(theta) * 0.8f;
      float pz = (float)Math.Sin(theta) * 0.8f;
      go.transform.position = new Vector3(px, 0.5f, pz);
    }
  }
}
