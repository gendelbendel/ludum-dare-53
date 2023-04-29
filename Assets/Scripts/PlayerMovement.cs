using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  Vector2 input;
  Rigidbody2D rigidBody;
  float moveSpeed = 5f;

  // Start is called before the first frame update
  void Start()
  {
    rigidBody = GetComponent<Rigidbody2D>();
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
