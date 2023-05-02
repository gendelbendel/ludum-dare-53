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
  GameObject table;
  CustomerManager customerManager;

  float maxZoom = 15f;
  float minZoom = 3f;
  float zoomChange = 1f;
  float startZoom = 5f;

  int purchasesMade { get; set; }

  void Awake()
  {
    // Debug.Log("Player awake!");

    GetComponent<SpriteRenderer>().sprite = null;

    rigidBody = GetComponent<Rigidbody2D>();
    outfit = GetComponentInChildren<Outfit>();
    myUI = FindObjectOfType<GameUI>();
    cvm = FindObjectOfType<CinemachineVirtualCamera>();
    table = GameObject.Find("Table");
    customerManager = FindObjectOfType<CustomerManager>();
  }

  void Start()
  {
    purchasesMade = 0;
    gameSession = FindObjectOfType<GameSession>();

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
    if (table != null)
    {
      if (Vector2.Distance(transform.position, table.transform.position) > 1.5f)
      {
        if (myUI.ItemsOpen)
          myUI.ToggleItems();
        if (!myUI.standHereEnabled)
        {
          myUI.ToggleStandHere();

        }
        if (myUI.standHereButtonEnabled)
        {
          myUI.ToggleStandHereButton();
        }
      }
      else
      {
        if (myUI.standHereEnabled)
        {
          myUI.ToggleStandHere();
        }
        if (!myUI.standHereButtonEnabled && customerManager.currentCustomer)
        {
          if (customerManager.currentCustomer.Waiting && customerManager.currentCustomer.Entering)
            myUI.ToggleStandHereButton();
        }
      }
      // Debug.Log("MAX CUSTOMERS: " + customerManager.maxCustomers);
      if (purchasesMade >= customerManager.maxCustomers)
      {
        myUI.ProgressScreen();
      }
    }

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
    if (Vector2.Distance(transform.position, table.transform.position) < 1.5f)
    {
      if (value.isPressed && customerManager.currentCustomer.Waiting && customerManager.currentCustomer.Entering)
        myUI.ToggleItems();
    }
  }

  void OnAccept(InputValue value)
  {
    if (value.isPressed && myUI.ItemsOpen)
    {
      EvaluateChoice(Customer.ChoiceValue.Accept);
      myUI.ToggleItems();
      myUI.ToggleStandHereButton();
    }
  }

  void OnDeny(InputValue value)
  {
    if (value.isPressed && myUI.ItemsOpen)
    {
      EvaluateChoice(Customer.ChoiceValue.Deny);
      myUI.ToggleItems();
      myUI.ToggleStandHereButton();
    }
  }

  void EvaluateChoice(Customer.ChoiceValue choice)
  {
    purchasesMade++;
    Customer currentCustomer = customerManager.currentCustomer;
    if (currentCustomer.Waiting && currentCustomer.Entering)
    {

      currentCustomer.FinishQuest();
      if (customerManager.nextCustomer != null)
        customerManager.nextCustomer.BeginWalkingInside();
      AddGold(currentCustomer, choice);
    }
  }

  void AddGold(Customer customer, Customer.ChoiceValue choice)
  {
    if (choice == customer.correctChoice)
    {
      myUI.AddGold(customer.goldValue);
      myUI.PlayGoldSound();
    }
    else
    {
      myUI.AddGold(-customer.goldValue);
      myUI.PlayEvilSound();
    }
  }

  // void OnPageForward(InputValue value)
  // {
  //   // Debug.Log("Journal toggled, current state: " + value.ToString());
  //   // if (value.isPressed && myUI.IsJournalOpen())
  //   //   myUI.PageForward();
  //   if (value.isPressed)
  //     myUI.ToggleItems();
  // }

  // void OnPageBackward(InputValue value)
  // {
  //   // Debug.Log("Journal toggled, current state: " + value.ToString());
  //   if (value.isPressed && myUI.IsJournalOpen())
  //     myUI.PageBackward();
  // }

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
