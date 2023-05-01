using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer : MonoBehaviour
{
  float maxTimeBetweenOutfitChanges = 1f;
  float outfitTimer = 1f;

  float maxWaitTime = 2f;
  float waitTimer = 2f;

  float moveSpeed = 3.6f;

  Outfit outfit;

  public bool Entering { get; set; }
  public bool Waiting { get; set; }
  int pointIndex;

  CustomerManager customerManager;
  Vector3[] currentPoints;

  Rigidbody2D myRigidBody;

  public enum PackageType
  {
    Letter, Package, OddObject
  }

  public PackageType packageType { get; set; }
  public int packageQuantity { get; set; }
  public float packageWeight { get; set; }
  public string packageDestination { get; set; }
  public string comment { get; set; }

  void Awake()
  {
    GetComponent<SpriteRenderer>().sprite = null;
    outfit = GetComponentInChildren<Outfit>();
    customerManager = FindObjectOfType<CustomerManager>();
    myRigidBody = GetComponent<Rigidbody2D>();
    Entering = true;
    Waiting = true;
    pointIndex = 0;
    packageType = PackageType.Letter;
    packageQuantity = 0;
    packageWeight = 0;
    packageDestination = "Nowhere";
    comment = "I'm still waking up";
    Debug.Log("Awake: " + transform.position.x + ", " + transform.position.y);
  }

  void Start()
  {
    Debug.Log("Customer start!");

    outfit.SetRandomOutfit();

    currentPoints = customerManager.GetEnterPathVectors();
    Debug.Log("Start: " + transform.position.x + ", " + transform.position.y);

  }

  void FixedUpdate()
  {
    WalkTowardsPoint();
  }

  void Update()
  {
    UpdateTimer();
    Wait();
  }

  void UpdateTimer()
  {
    outfitTimer -= Time.deltaTime;
    if (outfitTimer < 0)
    {
      outfit.SetRandomOutfit();
      outfitTimer = maxTimeBetweenOutfitChanges;
    }
  }

  void Wait()
  {
    if (Waiting && !Entering)
    {
      waitTimer -= Time.deltaTime;
      if (waitTimer < 0)
      {
        Destroy(gameObject);
      }
    }
  }

  public void BeginWalkingInside()
  {

    Waiting = false;
  }

  public void FinishQuest()
  {
    Waiting = false;
    Entering = false;
    pointIndex = 0;
    waitTimer = maxWaitTime;
    currentPoints = customerManager.GetExitPathVectors();
    customerManager.currentCustomer = null;
  }

  void WalkTowardsPoint()
  {
    if (!Waiting && pointIndex <= currentPoints.Length - 1)
    {
      Vector2 newPos = Vector2.MoveTowards(transform.position, currentPoints[pointIndex], moveSpeed * Time.deltaTime);
      myRigidBody.MovePosition(newPos);
      if (transform.position == currentPoints[pointIndex])
      {
        pointIndex++;
      }
      if (pointIndex == currentPoints.Length)
      {
        Waiting = true;
      }
    }
  }

}
