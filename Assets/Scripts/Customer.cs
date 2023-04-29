using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Customer : MonoBehaviour
{
  float maxTimeBetweenOutfitChanges = 1f;
  float outfitTimer = 1f;
  Outfit outfit;

  void Start()
  {
    GetComponent<SpriteRenderer>().sprite = null;
    outfit = GetComponentInChildren<Outfit>();
    outfit.SetRandomOutfit();
  }

  void Update()
  {
    UpdateTimer();
  }

  void UpdateTimer()
  {
    outfitTimer -= Time.deltaTime;
    if (outfitTimer < 0)
    {
      outfit.SetRandomOutfit();
      outfitTimer = maxTimeBetweenOutfitChanges;
    }
  }


}
