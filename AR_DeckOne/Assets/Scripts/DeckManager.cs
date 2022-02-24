//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  21-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance { set; get; }

    public Sprite errorCard;

    //> The following variables are / will be linked to other classes
    private List<XRReferenceImage> ReferenceImageList;

    private List<CardAssignment> Deck;
    private int emptyDeckSlot = 0;

    private void Awake()
    {
        if (Instance == null)   //< With this if-structure it is IMPOSSIBLE to create more than one instance.
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); //< Referring to the gameObject, this singleton script (class) is attached to.
        }
        else
        {
            Destroy(this.gameObject);   //< If you somehow still get to create a new singleton gameobject regardless, destroy the new one.
        }
    }

    void Start()
    {
        Deck = new List<CardAssignment>();

        //> Establishing connections to the ReferenceImageList in the GameManager
        ReferenceImageList = GameManager.Instance.GetReferenceImageList();

        //> Initializing the deck
        InitializeDeck();
    }

    public void InitializeDeck()
    {
        //> Fills the deck with one CardAssignment per referenceImage in gameManager's ReferenceImageList
        //  The assigned cardImage at this state is null
        for (int i = 0; i < ReferenceImageList.Count; i++)
        {
            Deck.Add(new CardAssignment(ReferenceImageList[i], null));
            //Deck.Add(new CardAssignment(ReferenceImageList[i], CardImageList[randomCardIndex()]));    //< I tested out how assigning random cards instead would work

            //Debug.Log($"Card {ReferenceImageList[i].name} has been added to the deck.");
        }

        /*
        if (ReferenceImageList.Count == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < ReferenceImageList.Count; i++)
            {
                Deck.Add(new CardAssignment(ReferenceImageList[i], CardImageList[0]));
                Debug.Log($"Card {ReferenceImageList[i].name} has been added to the deck.");
            }
        }
        */ // ARCHIVED
    }

    /* DEPRECATED, could be reused as "OverwritePlayingCard"
    public void SetAssignedCardImage(int deckIndex, Sprite cardImageInput)
    {
        Deck[deckIndex].cardImage = cardImageInput;
        Debug.Log($"Updated card \"{Deck[deckIndex].referenceImage.name}\" to display \"{cardImageInput.name}\".");
    }
    */

    //> This function is called by the DeckBuilder to add sprites from their list of "ChosenCards" to the game.
    //  This function automatically assigns these sprites to referenceImage which do not represent any sprite yet.
    public void AddPlayingCard(Sprite cardImageInput)
    {
        if (emptyDeckSlot < ReferenceImageList.Count)
        {
            Deck[emptyDeckSlot].cardImage = cardImageInput;
            Debug.Log($"Setup card {emptyDeckSlot+1}: \"{Deck[emptyDeckSlot].referenceImage.name}\" -> \"{cardImageInput.name}\"");

            emptyDeckSlot += 1;
        }
        else
        {
            Debug.LogWarning($"You cannot add more than {ReferenceImageList.Count} cards to this deck. Discarding {cardImageInput.name} now.");
        }
    }

    //> This function is called by the PlayingCards to fetch the cardImage that has been assigned to their referenceImage
    public Sprite FetchCardImage(XRReferenceImage refImageInput)  
    {
        foreach (CardAssignment cardAssignment in Deck)
        {
            if (refImageInput == cardAssignment.referenceImage)
            {
                if (cardAssignment.cardImage == null)
                {
                    Debug.LogWarning($"Deck does not contain a cardImage for referenceImage {refImageInput.name}. Falling back to cardImage { errorCard.name}.");
                    return errorCard;
                }
                else
                {
                    return cardAssignment.cardImage;
                }
            }
        }
        Debug.LogWarning($"Deck does not contain the referenceImage \"{refImageInput.name}\". (impossible case)");
        return null;
    }

    public int GetMaxDeckSize()
    {
        return Deck.Count;
    }

    /* ARCHIVED
    private int randomCardIndex()
    {
        return (int)Random.Range(0, CardImageList.Count);    //< Gives out a minimum integer of 0 and maximum integer of {highest CardImageList index}.
                                                             //< That's because "CardImageList.Count" gives out the length, not the highest index, but (int)Random.Range excludes the {maxRange} value
                                                             //< See: https://docs.unity3d.com/ScriptReference/Random.Range.html
    }
    */
}


public class CardAssignment
{    
    public XRReferenceImage referenceImage { get; set; }
    public Sprite cardImage { get; set; }

    public CardAssignment(XRReferenceImage _referenceImage, Sprite _cardImage)
    {
        referenceImage = _referenceImage;
        cardImage = _cardImage;
    }
}