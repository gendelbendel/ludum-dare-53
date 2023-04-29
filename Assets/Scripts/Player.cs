using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  Vector2 input;
  Rigidbody2D rigidBody;
  float moveSpeed = 5f;
  Outfit outfit;

  // Start is called before the first frame update
  void Start()
  {
    GetComponent<SpriteRenderer>().sprite = null;
    rigidBody = GetComponent<Rigidbody2D>();
    outfit = GetComponentInChildren<Outfit>();
    // outfit.SetOutfit(0, 0, 0, 0);
    outfit.SetRandomOutfit();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }

  void Move()
  {
    Vector2 velocity = new Vector2(moveSpeed * input.x, moveSpeed * input.y);
    rigidBody.velocity = velocity;
  }

  void OnMove(InputValue value)
  {
    input = value.Get<Vector2>();
  }
}