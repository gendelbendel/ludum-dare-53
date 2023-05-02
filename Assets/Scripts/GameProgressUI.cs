using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameProgressUI : MonoBehaviour
{

  GameSession gameSession;
  [SerializeField] Sprite success;
  [SerializeField] Sprite failure;

  Animator animator;

  int goldSubtract = 40;
  int goldAddedPerDay = 20;


  private void Awake()
  {
    gameSession = FindObjectOfType<GameSession>();
  }

  int CalculateRent()
  {
    return goldSubtract + (goldAddedPerDay * (gameSession.day - 1));
  }

  int CalculateNewGold(int rent)
  {
    return gameSession.Gold - rent;
  }

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();

    int rent = CalculateRent();
    int moneyAfterRent = CalculateNewGold(CalculateRent());
    GameObject.Find("Day Text").GetComponent<TextMeshProUGUI>().text = "Results for Day: " + gameSession.day.ToString();
    GameObject.Find("Earned Gold").GetComponent<TextMeshProUGUI>().text = gameSession.Gold.ToString();
    GameObject.Find("Rent Cost").GetComponent<TextMeshProUGUI>().text = rent.ToString();
    GameObject.Find("New Gold").GetComponent<TextMeshProUGUI>().text = moneyAfterRent.ToString();
    if (moneyAfterRent > 0)
    {
      GameObject.Find("Portrait").GetComponent<Image>().sprite = success;
      gameSession.Gold = moneyAfterRent;
      gameSession.day++;
      gameSession.difficulty++;
      if (gameSession.difficulty > 3)
      {
        gameSession.difficulty = 3;
      }
    }
    else
    {
      GameObject.Find("Portrait").GetComponent<Image>().sprite = failure;
      GameObject.Find("Continue Button").SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartOver()
  {
    animator.SetTrigger("restart_game");
  }

  public void Continue()
  {
    animator.SetTrigger("continue_game");

  }
}
