using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutfitCustomization : MonoBehaviour
{
  int[] bodyChoices = new[] { 0, 1, 48, 49, 96, 97, 140, 141 };

  int[] pantsChoices = new[] { 2, 3, 50, 51, 98, 99, 142, 143,
    188, 189, 236, 237, 278, 279, 324, 325, 370, 371, 408, 409 };

  int[] shirtChoices = Enumerable.Range(4, 12)
    .Concat(Enumerable.Range(52, 12))
    .Concat(Enumerable.Range(100, 12))
    .Concat(Enumerable.Range(144, 12))
    .Concat(Enumerable.Range(190, 12))
    .Concat(Enumerable.Range(238, 12))
    .Concat(Enumerable.Range(280, 12))
    .Concat(Enumerable.Range(326, 12))
    .Concat(Enumerable.Range(372, 12))
    .Concat(Enumerable.Range(410, 12)).ToArray();

  int[] hairChoices = Enumerable.Range(16, 8)
    .Concat(Enumerable.Range(64, 8))
    .Concat(Enumerable.Range(112, 8))
    .Concat(Enumerable.Range(156, 8))
    .Concat(Enumerable.Range(202, 8))
    .Concat(Enumerable.Range(250, 8))
    .Concat(Enumerable.Range(292, 8))
    .Concat(Enumerable.Range(338, 8))
    .Concat(Enumerable.Range(384, 4))
    .Concat(Enumerable.Range(422, 4))
    .Concat(Enumerable.Range(438, 4))
    .Concat(Enumerable.Range(444, 4)).ToArray();

  Sprite[] sprites;

  void Awake()
  {
    sprites = Resources.LoadAll<Sprite>("Characters");
  }

  public int GetMaxBodyCount()
  {
    return bodyChoices.Length;
  }

  public int GetMaxPantsCount()
  {
    return pantsChoices.Length;
  }

  public int GetMaxShirtCount()
  {
    return shirtChoices.Length;
  }

  public int GetMaxHairCount()
  {
    return hairChoices.Length;
  }

  public int GetNextBodyIndex(int index)
  {
    if (index + 1 >= GetMaxBodyCount()) return 0;
    return index + 1;
  }

  public int GetNextPantsIndex(int index)
  {
    if (index + 1 >= GetMaxPantsCount()) return 0;
    return index + 1;
  }

  public int GetNextShirtIndex(int index)
  {
    if (index + 1 >= GetMaxShirtCount()) return 0;
    return index + 1;
  }

  public int GetNextHairIndex(int index)
  {
    if (index + 1 >= GetMaxHairCount()) return 0;
    return index + 1;
  }

  public int GetPreviousBodyIndex(int index)
  {
    if (index - 1 <= 0) return GetMaxBodyCount() - 1;
    return index - 1;
  }

  public int GetPreviousPantsIndex(int index)
  {
    if (index - 1 <= 0) return GetMaxPantsCount() - 1;
    return index - 1;
  }

  public int GetPreviousShirtIndex(int index)
  {
    if (index - 1 <= 0) return GetMaxShirtCount() - 1;
    return index - 1;
  }

  public int GetPreviousHairIndex(int index)
  {
    if (index - 1 <= 0) return GetMaxHairCount() - 1;
    return index - 1;
  }

  public int GetRandomBodyIndex()
  {
    return new System.Random().Next(GetMaxBodyCount());
  }

  public int GetRandomPantsIndex()
  {
    return new System.Random().Next(GetMaxPantsCount());
  }

  public int GetRandomShirtIndex()
  {
    return new System.Random().Next(GetMaxShirtCount());
  }

  public int GetRandomHairIndex()
  {
    return new System.Random().Next(GetMaxHairCount());
  }

  public Sprite GetBodySprite(int index)
  {
    string spriteName = "Characters_" + bodyChoices[index].ToString();
    return FindSpriteByName(spriteName);
  }

  public Sprite GetPantsSprite(int index)
  {
    string spriteName = "Characters_" + pantsChoices[index].ToString();
    return FindSpriteByName(spriteName);
  }

  public Sprite GetShirtSprite(int index)
  {
    string spriteName = "Characters_" + shirtChoices[index].ToString();
    return FindSpriteByName(spriteName);
  }

  public Sprite GetHairSprite(int index)
  {
    string spriteName = "Characters_" + hairChoices[index].ToString();
    return FindSpriteByName(spriteName);
  }

  public Sprite FindSpriteByName(string name)
  {
    // Debug.Log("name lookup: " + name);
    return Array.Find(sprites, sprite => sprite.name == name);
  }
}
