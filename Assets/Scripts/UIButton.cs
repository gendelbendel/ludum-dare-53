using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
  [SerializeField] UnityEvent func;

  void Start()
  {
    GetComponentInChildren<Button>().onClick.AddListener(func.Invoke);
  }

}
