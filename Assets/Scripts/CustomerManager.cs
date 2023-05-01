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
  public DifficultyManager diffManager;

  int currentCustomerCount;

  void Awake()
  {
    currentCustomerCount = 1;
    startingPosition = new Vector2(3, -11);
    enterPath = GameObject.Find("Paths/Enter");
    exitPath = GameObject.Find("Paths/Exit");
    currentCustomer = CreateCustomer();
    diffManager = FindObjectOfType<DifficultyManager>();
  }

  void Start()
  {
    currentCustomer.BeginWalkingInside();
    FindObjectOfType<GameUI>().UpdateItemsDisplay(currentCustomer);
  }

  Customer CreateCustomer()
  {
    GameObject go = GameObject.Instantiate(customerPrefab);
    go.transform.position = startingPosition;
    go.name = "Customer " + currentCustomerCount;
    currentCustomerCount++;
    Customer customer = go.GetComponent<Customer>();

    return customer;
  }

  void Update()
  {
    if (!currentCustomer && nextCustomer)
    {
      currentCustomer = nextCustomer;
      FindObjectOfType<GameUI>().UpdateItemsDisplay(currentCustomer);
      nextCustomer = null;
    }
    if (currentCustomer && !nextCustomer && currentCustomer.Entering && currentCustomer.Waiting)
    {
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
