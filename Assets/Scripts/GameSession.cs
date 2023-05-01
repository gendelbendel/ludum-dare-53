using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
  int _bodyIndex;
  int _pantsIndex;
  int _shirtIndex;
  int _hairIndex;
  string playerName;
  PlayerInput _playerInput;
  public static GameSession gameSession;

  void Awake()
  {
    Debug.Log(SceneManager.GetActiveScene().name);
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
    if (gameSession != null)
    {
      Destroy(gameObject);
      return;
    }

    gameSession = this;

    Debug.Log("GameSession Awake _bodyIndex: " + _bodyIndex);
    _playerInput = FindObjectOfType<Player>().GetComponent<PlayerInput>();
    if (SceneManager.GetActiveScene().name == "NewPlayerScene")
    {
      SetUIActionMap();
    }
    else
    {
      SetPlayerActionMap();
    }
    DontDestroyOnLoad(gameObject);

  }

  public void SetPlayerActionMap()
  {
    GameSession.gameSession._playerInput.SwitchCurrentActionMap("Player");
  }

  public void SetUIActionMap()
  {
    _playerInput.SwitchCurrentActionMap("UI");
  }

  public void SetPlayerOutfit(int bodyIndex, int pantsIndex, int shirtIndex, int hairIndex)
  {
    GameSession.gameSession._bodyIndex = bodyIndex;
    GameSession.gameSession._pantsIndex = pantsIndex;
    GameSession.gameSession._shirtIndex = shirtIndex;
    GameSession.gameSession._hairIndex = hairIndex;
  }

  public void SetPlayerBody(int bodyIndex)
  {
    GameSession.gameSession._bodyIndex = bodyIndex;
  }

  public void SetPlayerPants(int pantsIndex)
  {
    GameSession.gameSession._pantsIndex = pantsIndex;
  }

  public void SetPlayerShirt(int shirtIndex)
  {
    GameSession.gameSession._shirtIndex = shirtIndex;
  }

  public void SetPlayerHair(int hairIndex)
  {
    GameSession.gameSession._hairIndex = hairIndex;
  }

  public void SetPlayerName(string name)
  {
    GameSession.gameSession.playerName = name;
  }

  public string GetPlayerName()
  {
    return GameSession.gameSession.playerName;
  }

  public int GetPlayerBody()
  {
    Debug.Log("Player body: " + GameSession.gameSession._bodyIndex);
    return GameSession.gameSession._bodyIndex;
  }

  public int GetPlayerPants()
  {
    Debug.Log("Player pants: " + GameSession.gameSession._pantsIndex);

    return GameSession.gameSession._pantsIndex;
  }

  public int GetPlayerShirt()
  {
    Debug.Log("Player shirt: " + GameSession.gameSession._shirtIndex);

    return GameSession.gameSession._shirtIndex;
  }

  public int GetPlayerHair()
  {
    Debug.Log("Player hair: " + GameSession.gameSession._hairIndex);

    return GameSession.gameSession._hairIndex;
  }
}
