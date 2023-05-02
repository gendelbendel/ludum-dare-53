using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputDeviceChangeHandlerSpriterenderer : MonoBehaviour
{
  // refs to Button's components
  private SpriteRenderer buttonImage;

  // refs to your sprites
  [SerializeField] public Sprite gamepadImage;
  [SerializeField] public Sprite keyboardImage;

  void Awake()
  {
    buttonImage = GetComponent<SpriteRenderer>();
    PlayerInput input = FindObjectOfType<PlayerInput>();
    updateButtonImage(input.currentControlScheme);
  }

  void OnEnable()
  {
    InputUser.onChange += onInputDeviceChange;
  }

  void OnDisable()
  {
    InputUser.onChange -= onInputDeviceChange;
  }

  void onInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
  {
    if (change == InputUserChange.ControlSchemeChanged)
    {
      updateButtonImage(user.controlScheme.Value.name);
    }
  }

  void updateButtonImage(string schemeName)
  {
    // assuming you have only 2 schemes: keyboard and gamepad
    if (schemeName.Equals("Gamepad"))
    {
      buttonImage.sprite = gamepadImage;
    }
    else
    {
      // Debug.Log(buttonImage.color.a);
      buttonImage.sprite = keyboardImage;
    }
  }
}
