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

  bool entering;
  bool waiting;
  int pointIndex;

  CustomerManager customerManager;
  Vector3[] currentPoints;

  Rigidbody2D myRigidBody;

  void Awake()
  {
    GetComponent<SpriteRenderer>().sprite = null;
    outfit = GetComponentInChildren<Outfit>();
    customerManager = FindObjectOfType<CustomerManager>();
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  void Start()
  {
    entering = true;
    waiting = false;
    pointIndex = 0;

    outfit.SetRandomOutfit();

    currentPoints = customerManager.GetEnterPathVectors();
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
    if (waiting)
    {
      waitTimer -= Time.deltaTime;
      if (waitTimer < 0 && entering)
      {
        waiting = false;
        entering = false;
        pointIndex = 0;
        waitTimer = maxWaitTime;
        currentPoints = customerManager.GetExitPathVectors();
      }
      else if (waitTimer < 0 && !entering)
      {
        Destroy(gameObject);
      }
    }
  }

  void WalkTowardsPoint()
  {
    if (pointIndex <= currentPoints.Length - 1)
    {
      Vector2 newPos = Vector2.MoveTowards(transform.position, currentPoints[pointIndex], moveSpeed * Time.deltaTime);
      myRigidBody.MovePosition(newPos);
      if (transform.position == currentPoints[pointIndex])
      {
        pointIndex++;
      }
      if (pointIndex == currentPoints.Length)
      {
        waiting = true;
      }
    }
  }

}
