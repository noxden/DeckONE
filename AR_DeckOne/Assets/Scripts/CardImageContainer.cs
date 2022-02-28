//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  23-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//
// Code quality: Very bad
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardImageContainer : MonoBehaviour
{
    public Sprite cardImage;
    public DeckBuilder deckBuilder;
    
    //public GameObject cardCountIndicator;

    private int cardCount = 0;
    private Text cardCountText;

    public static int maxAmountOfSameCards = 3;


    private void Start()
    {
        cardCountText = GetComponentInChildren<Text>();
        //Lean.Gui.LeanBox backgroundCircle = cardCountIndicator.GetComponent<Lean.Gui.LeanBox>;

        Image imageComponent = GetComponentInChildren<Image>();
        imageComponent.sprite = cardImage;
    }

    public void AddCard()
    {
        //> Update cardCount variable
        if (cardCount >= maxAmountOfSameCards)
        {
            cardCount = 0;
            deckBuilder.RemoveFromChosenCards(cardImage, maxAmountOfSameCards);
        }
        else
        {
            cardCount += 1;
            deckBuilder.AddToChosenCards(cardImage);
        }
        //Debug.Log($"Variable cardCount has been changed to {cardCount}");

        UpdateUI();
    }

    //> Updates visual representation of this card
    private void UpdateUI()
    {
        cardCountText.text = cardCount.ToString();
        BuildDeckManager.Instance.UpdateUI();
    }
}
