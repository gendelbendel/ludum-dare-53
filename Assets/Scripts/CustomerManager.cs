using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomerManager : MonoBehaviour
{

  GameObject enterPath;
  GameObject exitPath;

  Vector2 startingPosition;

  public GameObject customerPrefab;
  public Customer currentCustomer;
  public Customer nextCustomer;

  int currentCustomerCount;

  void Awake()
  {
    Debug.Log("Customer manager awake!");
    currentCustomerCount = 1;
    startingPosition = new Vector2(3, -11);
    enterPath = GameObject.Find("Paths/Enter");
    exitPath = GameObject.Find("Paths/Exit");
    currentCustomer = CreateCustomer();
  }

  void Start()
  {
    Debug.Log("Customer manager start!");
    currentCustomer.BeginWalkingInside();
    Debug.Log("Waiting? " + currentCustomer.Waiting);
  }

  Customer CreateCustomer()
  {
    Debug.Log("Creating a customer!");
    GameObject go = GameObject.Instantiate(customerPrefab);
    go.transform.position = startingPosition;
    go.name = "Customer " + currentCustomerCount;
    currentCustomerCount++;
    return go.GetComponent<Customer>();
  }

  void Update()
  {
    if (!currentCustomer && nextCustomer)
    {
      currentCustomer = nextCustomer;
      nextCustomer = null;
    }
    if (currentCustomer && !nextCustomer && currentCustomer.Entering && currentCustomer.Waiting)
    {
      Debug.Log("Creating next customer!");
      nextCustomer = CreateCustomer();
    }
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
