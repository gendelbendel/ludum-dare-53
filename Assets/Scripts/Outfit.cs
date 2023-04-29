using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfit : MonoBehaviour
{
  SpriteRenderer body;
  SpriteRenderer pants;
  SpriteRenderer shirt;
  SpriteRenderer hair;

  void Awake()
  {
    body = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
    pants = gameObject.transform.Find("Pants").GetComponent<SpriteRenderer>();
    shirt = gameObject.transform.Find("Shirt").GetComponent<SpriteRenderer>();
    hair = gameObject.transform.Find("Hair").GetComponent<SpriteRenderer>();
  }

  public void SetOutfit(int bodyIndex, int pantsIndex, int shirtIndex, int hairIndex)
  {
    OutfitCustomization outfitCustomizer = GameObject.Find("GameManager").GetComponent<OutfitCustomization>();
    body.sprite = outfitCustomizer.GetBodySprite(bodyIndex);
    pants.sprite = outfitCustomizer.GetPantsSprite(pantsIndex);
    shirt.sprite = outfitCustomizer.GetShirtSprite(shirtIndex);
    hair.sprite = outfitCustomizer.GetHairSprite(hairIndex);
  }

  public void SetRandomOutfit()
  {
    OutfitCustomization outfitCustomizer = GameObject.Find("GameManager").GetComponent<OutfitCustomization>();
    body.sprite = outfitCustomizer.GetRandomBodySprite();
    pants.sprite = outfitCustomizer.GetRandomPantsSprite();
    shirt.sprite = outfitCustomizer.GetRandomShirtSprite();
    hair.sprite = outfitCustomizer.GetRandomHairSprite();
  }
}
