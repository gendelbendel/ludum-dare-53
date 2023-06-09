using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DifficultyManager : MonoBehaviour
{
  GameSession gameSession;

  string[] commentsLevel1 = {
    "I'm still waking up... Where's the coffee.",
    "They keep talking about some sickness spreading... Oh well.",
    "The government controls every aspect of our lives, even the packages we receive.",
    "Our air is poisoned, our packages monitored. Is this what freedom looks like?",
    "When the government controls what we receive, they control what we think.",
    "Sickness in the air, control of packages, it's all a means of oppression.",
    "I never imagined that the simple act of receiving a package would be a luxury.",
    "We've traded our privacy for the illusion of safety in this dystopian city.",
    "The air stinks of disease, and the packages we receive are a reminder of our captivity.",
    "In this city, packages are the only connection we have to the outside world.",
    "We can't even trust the air we breathe, let alone the packages we receive.",
    "In a world where packages are controlled, the only thing we truly own is our thoughts."
  };

  string[] commentsLevel2 = {
    "The government's grip on our packages is tightening, and the air is getting worse.",
    "I fear the sickness in the air is just the beginning of our troubles.",
    "As the government's control over our packages grows, so does our desperation.",
    "We're suffocating under the weight of oppressive package control and polluted air.",
    "The government's obsession with packages is blinding them to the real problems we face.",
    "I can't help but wonder if the sickness in the air is intentional, a way to keep us under control.",
    "Our packages are becoming scarce, and the government is using them as a tool of manipulation.",
    "In this dystopian city, the air and packages are both weapons of the ruling class.",
    "We've lost so much already, and I fear there's no end to the government's tyranny in sight.",
    "The government's control over our packages and the air we breathe is a reminder that we're living in a nightmare."
  };

  string[] commentsLevel3 = {
    "The government's control over our packages and the air we breathe is unacceptable - we need to take action.",
    "Our packages are our lifeline, and the government's attempt to control them is an attack on our basic freedoms.",
    "We need to stand up to the government's package control and demand our right to receive what we need.",
    "The sickness in the air is a direct result of the government's neglect - it's time for us to demand change.",
    "Our voices are our only weapon against the government's package control and environmental destruction.",
    "The government's control over our packages is a symbol of their desire for total domination - we can't let them win.",
    "The air is making us sick, and the government's package control is making us poor - it's time for a rebellion.",
    "We won't be silenced by the government's attempts to control our packages and our lives - we demand freedom.",
    "The government's obsession with package control is a distraction from the real problems facing our city.",
    "We may be living in a dystopia, but we have the power to fight back against the government's package control and environmental destruction."
  };

  private void Awake()
  {
    gameSession = FindObjectOfType<GameSession>();
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  // I hate this
  public void RandomizeQuest(Customer customer)
  {
    System.Random random = new System.Random();
    if (gameSession.difficulty == 1)
    {
      customer.packageType = Customer.PackageType.Letter;
      int qty = random.Next(4);
      customer.packageQuantity = qty == 0 ? qty + 1 : qty;
      customer.packageWeight = (float)Decimal.Round(Convert.ToDecimal(RandomFloat(random, 5.5f, 20f)), 2);
      customer.packageDestination = GenerateName(random, 8) + " City";
      customer.comment = commentsLevel1[random.Next(commentsLevel1.Length - 1)];
      customer.correctChoice = customer.packageQuantity <= 1 ?
        Customer.ChoiceValue.Accept :
        Customer.ChoiceValue.Deny;
    }
    else if (gameSession.difficulty == 2)
    {
      customer.packageType = Customer.PackageType.Letter;
      int qty = random.Next(4);
      customer.packageQuantity = qty == 0 ? qty + 1 : qty;
      customer.packageWeight = (float)Decimal.Round(Convert.ToDecimal(RandomFloat(random, 5.5f, 20f)), 2);
      customer.packageDestination = GenerateName(random, 8) + " City";
      customer.comment = commentsLevel1[random.Next(commentsLevel1.Length - 1)];
      if (customer.packageQuantity <= 1 && customer.packageWeight < 15.0f)
      {
        customer.correctChoice = Customer.ChoiceValue.Accept;
      }
      else
      {
        customer.correctChoice = Customer.ChoiceValue.Deny;

      }
    }
    else if (gameSession.difficulty == 3)
    {
      customer.packageType = Customer.PackageType.Letter;
      int qty = random.Next(4);
      customer.packageQuantity = qty == 0 ? qty + 1 : qty;
      customer.packageWeight = (float)Decimal.Round(Convert.ToDecimal(RandomFloat(random, 5.5f, 20f)), 2);
      customer.packageDestination = GenerateName(random, 8) + " City";
      customer.comment = commentsLevel1[random.Next(commentsLevel1.Length - 1)];
      if (customer.packageQuantity <= 1 && customer.packageWeight < 15.0f && customer.packageDestination != "New York")
      {
        customer.correctChoice = Customer.ChoiceValue.Accept;
      }
      else
      {
        customer.correctChoice = Customer.ChoiceValue.Deny;
      }
    }
  }

  float RandomFloat(System.Random random, float min, float max)
  {
    double val = (random.NextDouble() * (max - min) + min);
    return (float)val;
  }

  // https://stackoverflow.com/questions/14687658/random-name-generator-in-c-sharp
  public string GenerateName(System.Random r, int len)
  {
    string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
    string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
    string Name = "";
    Name += consonants[r.Next(consonants.Length)].ToUpper();
    Name += vowels[r.Next(vowels.Length)];
    int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
    while (b < len)
    {
      Name += consonants[r.Next(consonants.Length)];
      b++;
      Name += vowels[r.Next(vowels.Length)];
      b++;
    }
    return Name;
  }
}
