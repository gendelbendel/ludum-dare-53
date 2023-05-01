using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomerManager : MonoBehaviour
{

  GameObject enterPath;
  GameObject exitPath;

  void Awake()
  {
    enterPath = GameObject.Find("Paths/Enter");
    exitPath = GameObject.Find("Paths/Exit");
  }

  public Vector3[] GetEnterPathVectors()
  {
    return enterPath.GetComponentsInChildren<Transform>()
      .Where(transform => transform.gameObject.name != "Enter")
      .OrderBy(transform => transform.gameObject.name)
      .Select(transform => transform.position).ToArray();
  }

  public Vector3[] GetExitPathVectors()
  {
    return exitPath.GetComponentsInChildren<Transform>()
      .Where(transform => transform.gameObject.name != "Exit")
      .OrderBy(transform => transform.gameObject.name)
      .Select(transform => transform.position).ToArray();
  }
}
