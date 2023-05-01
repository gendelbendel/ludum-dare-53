using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectNameCanvasScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    string name = gameObject.transform.parent.gameObject.name;
    GetComponentInChildren<TextMeshProUGUI>().text = name;
    GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
