using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextLinks : MonoBehaviour, IPointerClickHandler
{
  TMP_Text textBox;

  void Awake()
  {
    textBox = GetComponent<TMP_Text>();
  }

  public void OnPointerClick(PointerEventData myEvent)
  {
    Vector3 mouse = new Vector3(myEvent.position.x, myEvent.position.y, 0);

    int link = TMP_TextUtilities.FindIntersectingLink(textBox, mouse, null);
    if (link == -1) return;

    string linkID = textBox.textInfo.linkInfo[link].GetLinkID();
    Application.OpenURL(linkID);
  }
}
