using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfit : MonoBehaviour
{
  SpriteRenderer body;
  SpriteRenderer pants;
  SpriteRenderer shirt;
  SpriteRenderer hair;
  OutfitCustomization outfitCustomizer;

  int _bodyIndex;
  int _pantsIndex;
  int _shirtIndex;
  int _hairIndex;

  void Awake()
  {
    body = gameObject.transform.Find("Body").GetComponent<SpriteRenderer>();
    pants = gameObject.transform.Find("Pants").GetComponent<SpriteRenderer>();
    shirt = gameObject.transform.Find("Shirt").GetComponent<SpriteRenderer>();
    hair = gameObject.transform.Find("Hair").GetComponent<SpriteRenderer>();
    outfitCustomizer = GameObject.Find("GameManager").GetComponent<OutfitCustomization>();
  }

  public void ChangeBody(int bodyIndex)
  {
    _bodyIndex = outfitCustomizer.GetNextBodyIndex(bodyIndex - 1);
    body.sprite = outfitCustomizer.GetBodySprite(_bodyIndex);
  }

  public void ChangePants(int pantsIndex)
  {
    _pantsIndex = outfitCustomizer.GetNextPantsIndex(pantsIndex - 1);
    pants.sprite = outfitCustomizer.GetPantsSprite(_pantsIndex);
  }

  public void ChangeShirt(int shirtIndex)
  {
    _shirtIndex = outfitCustomizer.GetNextShirtIndex(shirtIndex - 1);
    shirt.sprite = outfitCustomizer.GetShirtSprite(_shirtIndex);
  }

  public void ChangeHair(int hairIndex)
  {
    _hairIndex = outfitCustomizer.GetNextHairIndex(hairIndex - 1);
    hair.sprite = outfitCustomizer.GetHairSprite(_hairIndex);
  }

  public void SetOutfit(int bodyIndex, int pantsIndex, int shirtIndex, int hairIndex)
  {
    ChangeBody(bodyIndex);
    ChangePants(pantsIndex);
    ChangeShirt(shirtIndex);
    ChangeHair(hairIndex);
  }

  public void SetRandomOutfit()
  {
    SetOutfit(outfitCustomizer.GetRandomBodyIndex(),
      outfitCustomizer.GetRandomPantsIndex(),
      outfitCustomizer.GetRandomShirtIndex(),
      outfitCustomizer.GetRandomHairIndex());
  }
}
