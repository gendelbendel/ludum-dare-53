using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameUI : MonoBehaviour
{
  Animator animator;
  bool startingGame;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    startingGame = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ToggleJournal()
  {
    Debug.Log("Journal toggled, current state: " + startingGame);
    if (startingGame)
      animator.SetTrigger("journal_close");
    else
      animator.SetTrigger("journal_open");
    startingGame = !startingGame;
  }

  public bool IsGameStarting()
  {
    return startingGame;
  }

  public void StartGame()
  {
    Debug.Log("Journal toggled, current state: " + startingGame);
    animator.SetTrigger("game_start");
  }

}
