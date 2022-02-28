//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  23-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//
// Code quality: Poor
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilder : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> AllCards;
    public List<Sprite> ChosenCards;    //< This list will later be filled by the player through UI buttons

    private void Start()
    {        
        //ChosenCards = new List<Sprite>(10);

        //> Establishing connection to the CardImageList in the GameManager
        //AllCardImages = GameManager.Instance.GetCardImageList();

        //BuildDeck();

        ChosenCards = new List<Sprite>();
    }

    public List<Sprite> GetAllCards()
    {
        AllCards.Sort(SortByName);
        return AllCards;
    }

    private int SortByName(Sprite s1, Sprite s2)
    {
        return s1.name.CompareTo(s2.name);
    }

    public void AddToChosenCards (Sprite cardImage)
    {
        ChosenCards.Add(cardImage);
        Debug.Log($"Added 1 \"{cardImage.name}\". ChosenCards now contains {ChosenCards.Count} entries.");
    }

    public void RemoveFromChosenCards (Sprite cardImage, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (ChosenCards.Contains(cardImage))
            {
                ChosenCards.Remove(cardImage);
            }
            else
            {
                Debug.Log($"Can't remove any more cards of type {cardImage.name} from List ChosenCards.");
            }
        }
        Debug.Log($"Removed {count} \"{cardImage.name}\". ChosenCards now contains {ChosenCards.Count} entries.");
    }

    public bool BuildDeck()    //< This function will later be called upon pressing the "Confirm Deck" button. (and after checking that the selection is valid, e.g. only half of referenceImageList.Count)
    {
        if (ChosenCards.Count != DeckManager.Instance.GetMaxDeckSize()/2)
        {
            Debug.Log($"Your deck needs to contain exactly {DeckManager.Instance.GetMaxDeckSize()} cards!");
            return false;       //< Could also be: "return (ChosenCards.Count != DeckManager.Instance.GetMaxDeckSize());"
        }

        foreach (Sprite chosenCard in ChosenCards)
        {
            DeckManager.Instance.AddPlayingCard(chosenCard);
        }
        return true;

        /*
        if (AllCardImages.Count == 0)
        {
            Debug.Log($"The image list is empty! There are no images to choose from!");
            return;
        }
        else
        {
            DeckManager.Instance.SetAssignedCardImage(3, AllCardImages[(int)Random.Range(0, AllCardImages.Count)]);
        }
        */
    }
}