using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player : MonoBehaviour
{
  Vector2 input;
  Rigidbody2D rigidBody;
  float moveSpeed = 5f;
  public Outfit outfit;
  GameSession gameSession;
  GameUI myUI;
  CinemachineVirtualCamera cvm;

  float maxZoom = 15f;
  float minZoom = 3f;
  float zoomChange = 1f;
  float startZoom = 5f;

  void Awake()
  {
    Debug.Log("Player awake!");

    GetComponent<SpriteRenderer>().sprite = null;

    gameSession = FindObjectOfType<GameSession>();
    rigidBody = GetComponent<Rigidbody2D>();
    outfit = GetComponentInChildren<Outfit>();
    myUI = FindObjectOfType<GameUI>();
    cvm = FindObjectOfType<CinemachineVirtualCamera>();
  }

  void Start()
  {
    outfit.SetOutfit(gameSession.GetPlayerBody(),
      gameSession.GetPlayerPants(),
      gameSession.GetPlayerShirt(),
      gameSession.GetPlayerHair());
    cvm.m_Lens.OrthographicSize = startZoom;
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

  void OnOpenJournal(InputValue value)
  {
    if (value.isPressed)
      myUI.ToggleJournal();
  }

  void OnStartQuest(InputValue value)
  {
    if (value.isPressed)
    {
      Customer currentCustomer = FindObjectOfType<CustomerManager>().currentCustomer;
      if (currentCustomer.Waiting && currentCustomer.Entering)
      {
        currentCustomer.FinishQuest();
        FindObjectOfType<CustomerManager>().nextCustomer.BeginWalkingInside();
      }
    }
  }

  void OnPageForward(InputValue value)
  {
    // Debug.Log("Journal toggled, current state: " + value.ToString());
    if (value.isPressed && myUI.IsJournalOpen())
      myUI.PageForward();
  }

  void OnPageBackward(InputValue value)
  {
    // Debug.Log("Journal toggled, current state: " + value.ToString());
    if (value.isPressed && myUI.IsJournalOpen())
      myUI.PageBackward();
  }

  void OnZoomIn(InputValue value)
  {
    if (!value.isPressed && cvm.m_Lens.OrthographicSize != minZoom)
    {
      cvm.m_Lens.OrthographicSize -= zoomChange;
    }
  }

  void OnZoomOut(InputValue value)
  {
    if (!value.isPressed && cvm.m_Lens.OrthographicSize != maxZoom)
    {
      cvm.m_Lens.OrthographicSize += zoomChange;
    }
  }

  void OnZoomReset(InputValue value)
  {
    if (!value.isPressed)
    {
      cvm.m_Lens.OrthographicSize = startZoom;
    }
  }
}
