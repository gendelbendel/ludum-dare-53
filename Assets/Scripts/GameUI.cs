using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GameUI : MonoBehaviour
{
  Animator journalAnimator;
  Animator itemsAnimator;
  Animator standHereAnimator;
  Animator standHereButtonAnimator;

  bool journalOpen;
  TextMeshProUGUI goldDisplay;
  GameSession gameSession;

  public bool ItemsOpen { get; set; }
  public bool standHereEnabled { get; set; }
  public bool standHereButtonEnabled { get; set; }

  [SerializeField] AudioClip gold;
  [SerializeField] AudioClip evil;
  AudioSource audioSource;

  void Awake()
  {
    journalAnimator = GameObject.Find("Full Journal").GetComponent<Animator>();
    itemsAnimator = GameObject.Find("Customer Delivery").GetComponent<Animator>();
    standHereAnimator = GameObject.Find("Arrow indicator").GetComponent<Animator>();
    standHereButtonAnimator = GameObject.Find("Press Button").GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
    goldDisplay = GameObject.Find("Gold Box").GetComponentInChildren<TextMeshProUGUI>();
  }

  void Start()
  {
    gameSession = FindObjectOfType<GameSession>();

    journalOpen = false;
    ItemsOpen = false;
    standHereEnabled = false;
    standHereButtonEnabled = false;
    Debug.Log("GOLD START: " + gameSession.Gold);
    UpdateGoldDisplay();
  }

  void Update()
  {

  }

  public void AddGold(int amt)
  {
    gameSession.Gold += amt;
    UpdateGoldDisplay();
  }

  public void PlayGoldSound()
  {
    audioSource.clip = gold;
    audioSource.Play();
  }

  public void PlayEvilSound()
  {
    audioSource.clip = evil;
    audioSource.Play();
  }

  void UpdateGoldDisplay()
  {
    goldDisplay.text = gameSession.Gold.ToString();
  }

  public void UpdateItemsDisplay(Customer customer)
  {
    GameObject.Find("Customer Name Text").GetComponent<TextMeshProUGUI>().text = "Name: " + customer.gameObject.name;
    GameObject.Find("Quantity Text").GetComponent<TextMeshProUGUI>().text = "Quantity: " + customer.packageQuantity.ToString();
    GameObject.Find("Weight Text").GetComponent<TextMeshProUGUI>().text = "Weight: " + customer.packageWeight.ToString() + "g";
    GameObject.Find("Destination Text").GetComponent<TextMeshProUGUI>().text = "Destination: " + customer.packageDestination;
    GameObject.Find("Customer Comment").GetComponent<TextMeshProUGUI>().text = "\"" + customer.comment + "\"";
  }

  public void ToggleJournal()
  {
    // Debug.Log("Journal toggled, current state: " + journalOpen);
    if (journalOpen)
      journalAnimator.SetTrigger("journal_close");
    else
      journalAnimator.SetTrigger("journal_open");
    journalOpen = !journalOpen;
  }

  public void ToggleStandHere()
  {
    Debug.Log("standHereEnabled, current state: " + standHereEnabled);
    if (standHereEnabled)
      standHereAnimator.SetTrigger("stand_here_off");
    else
      standHereAnimator.SetTrigger("stand_here_on");
    standHereEnabled = !standHereEnabled;
  }

  public void ToggleStandHereButton()
  {
    Debug.Log("standHereButtonEnabled, current state: " + standHereButtonEnabled);

    if (standHereButtonEnabled)
      standHereButtonAnimator.SetTrigger("table_button_off");
    else
      standHereButtonAnimator.SetTrigger("table_button_on");
    standHereButtonEnabled = !standHereButtonEnabled;
  }

  public void ToggleItems()
  {
    // Debug.Log("Items toggled, current state: " + ItemsOpen);
    if (ItemsOpen)
      itemsAnimator.SetTrigger("items_close");
    else
      itemsAnimator.SetTrigger("items_open");
    ItemsOpen = !ItemsOpen;
  }

  public bool IsJournalOpen()
  {
    return journalOpen;
  }

  public void PageForward()
  {
    journalAnimator.SetTrigger("page_forward");
  }

  public void PageBackward()
  {
    journalAnimator.SetTrigger("page_backward");
  }
}
