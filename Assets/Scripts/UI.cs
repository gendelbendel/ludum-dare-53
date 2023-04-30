using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI : MonoBehaviour
{
  Animator animator;
  bool journalOpen;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    journalOpen = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ToggleJournal()
  {
    Debug.Log("Journal toggled, current state: " + journalOpen);
    if (journalOpen)
      animator.SetTrigger("journal_close");
    else
      animator.SetTrigger("journal_open");
    journalOpen = !journalOpen;
  }

  public bool IsJournalOpen()
  {
    return journalOpen;
  }

  public void PageForward()
  {
    animator.SetTrigger("page_forward");
  }

  public void PageBackward()
  {
    animator.SetTrigger("page_backward");
  }
}
