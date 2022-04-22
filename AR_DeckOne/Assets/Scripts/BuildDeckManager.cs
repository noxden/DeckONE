//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  28-02-22
//----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildDeckManager : MonoBehaviour
{
    public static BuildDeckManager Instance { set; get; }

    public Text currentNumOfChosenCards;
    public Text correctNumOfChosenCards;
    public SceneChanger sceneChanger;   //< On ContinueButton

    private DeckBuilder deckBuilder;

    private void Awake()
    {
        if (Instance == null)   //< With this if-structure it is IMPOSSIBLE to create more than one instance.
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);   //< If you somehow still get to create a new singleton gameobject regardless, destroy the new one.
        }
    }

    void Start()
    {
        deckBuilder = FindObjectOfType<DeckBuilder>();

        StartCoroutine(WaitForDeckToBeFilled());
        //int correctCardAmount = DeckManager.Instance.GetMaxDeckSize() / 2;
        //correctNumOfChosenCards.text = correctCardAmount.ToString();
        currentNumOfChosenCards.text = deckBuilder.ChosenCards.Count.ToString();
    }

    IEnumerator WaitForDeckToBeFilled()
    {
        int correctCardAmount = 0;

        while (correctCardAmount == 0)
        {
            try
            {
                correctCardAmount = DeckManager.Instance.GetMaxDeckSize() / 2;
            }
            catch (NullReferenceException exception)
            {
                NullReferenceException myFavouriteException;    //< These two lines exists just to shut up the console xD
                myFavouriteException = exception;
            }
            yield return new WaitForSeconds(1);
        }
        correctNumOfChosenCards.text = correctCardAmount.ToString();
        
    }

    //> These functions are called by other classes
    public void UpdateUI()
    {
        currentNumOfChosenCards.text = deckBuilder.ChosenCards.Count.ToString();
    }

    public void TryBuildDeck()
    {
        if (deckBuilder.BuildDeck())
        {
            sceneChanger.ChangeScene();
        }
    }

}
