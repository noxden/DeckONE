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

public class DeckBuilder : MonoBehaviour
{
    //> The following variables are / will be linked to other classes
    //private List<Sprite> AllCardImages;

    public List<Sprite> ChosenCards;    //< This list will later be filled by the player through UI buttons

    private void Start()
    {
        //ChosenCards = new List<Sprite>(10);

        //> Establishing connection to the CardImageList in the GameManager
        //AllCardImages = GameManager.Instance.GetCardImageList();

        BuildDeck();
    }

    void BuildDeck()    //< This function will later be called upon pressing the "Confirm Deck" button. (and after checking that the selection is valid, e.g. only half of referenceImageList.Count)
    {
        foreach (Sprite chosenCard in ChosenCards)
        {
            DeckManager.Instance.AddPlayingCard(chosenCard);
        }
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