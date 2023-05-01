using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class NewPlayerUI : MonoBehaviour
{
  Animator animator;
  bool startingGame;
  GameSession gameSession;
  OutfitCustomization outfitCustomization;
  Player player;

  TextMeshProUGUI bodyCounter;
  TextMeshProUGUI pantsCounter;
  TextMeshProUGUI shirtCounter;
  TextMeshProUGUI hairCounter;

  void Awake()
  {
    player = FindObjectOfType<Player>();

    outfitCustomization = FindObjectOfType<OutfitCustomization>();

    bodyCounter = GetCounterText("Body").GetComponent<TextMeshProUGUI>();
    pantsCounter = GetCounterText("Pants").GetComponent<TextMeshProUGUI>();
    shirtCounter = GetCounterText("Shirt").GetComponent<TextMeshProUGUI>();
    hairCounter = GetCounterText("Hair").GetComponent<TextMeshProUGUI>();
  }

  void Start()
  {
    gameSession = FindObjectOfType<GameSession>();

    animator = GetComponent<Animator>();
    startingGame = false;

    gameSession.SetPlayerName("");
    gameSession.SetPlayerOutfit(2, 7, 10, 0);

    player.outfit.SetOutfit(2, 7, 10, 0);
    UpdateCounters();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void UpdateCounters()
  {
    bodyCounter.text = gameSession.GetPlayerBody().ToString();
    pantsCounter.text = gameSession.GetPlayerPants().ToString();
    shirtCounter.text = gameSession.GetPlayerShirt().ToString();
    hairCounter.text = gameSession.GetPlayerHair().ToString();
  }

  public void StartGame()
  {
    animator.SetTrigger("game_start");
  }

  public GameObject GetCounterText(string choice)
  {
    return GameObject.Find(choice + " Counter/Text (TMP)");
  }

  void UpdateBody(int newIndex)
  {
    gameSession.SetPlayerBody(newIndex);
    player.outfit.ChangeBody(newIndex);
    UpdateCounters();
  }

  public void IncrementBody()
  {
    int newIndex = outfitCustomization.GetNextBodyIndex(gameSession.GetPlayerBody());
    UpdateBody(newIndex);
  }

  public void DecrementBody()
  {
    int newIndex = outfitCustomization.GetPreviousBodyIndex(gameSession.GetPlayerBody());
    UpdateBody(newIndex);
  }

  void UpdatePants(int newIndex)
  {
    gameSession.SetPlayerPants(newIndex);
    player.outfit.ChangePants(newIndex);
    UpdateCounters();
  }

  public void IncrementPants()
  {
    int newIndex = outfitCustomization.GetNextPantsIndex(gameSession.GetPlayerPants());
    UpdatePants(newIndex);
  }

  public void DecrementPants()
  {
    int newIndex = outfitCustomization.GetPreviousPantsIndex(gameSession.GetPlayerPants());
    UpdatePants(newIndex);
  }

  void UpdateShirt(int newIndex)
  {
    gameSession.SetPlayerShirt(newIndex);
    player.outfit.ChangeShirt(newIndex);
    UpdateCounters();
  }

  public void IncrementShirt()
  {
    int newIndex = outfitCustomization.GetNextShirtIndex(gameSession.GetPlayerShirt());
    UpdateShirt(newIndex);
  }

  public void DecrementShirt()
  {
    int newIndex = outfitCustomization.GetPreviousShirtIndex(gameSession.GetPlayerShirt());
    UpdateShirt(newIndex);
  }

  void UpdateHair(int newIndex)
  {
    gameSession.SetPlayerHair(newIndex);
    player.outfit.ChangeHair(newIndex);
    UpdateCounters();
  }

  public void IncrementHair()
  {
    int newIndex = outfitCustomization.GetNextHairIndex(gameSession.GetPlayerHair());
    UpdateHair(newIndex);
  }

  public void DecrementHair()
  {
    int newIndex = outfitCustomization.GetPreviousHairIndex(gameSession.GetPlayerHair());
    UpdateHair(newIndex);
  }
}
