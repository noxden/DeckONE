//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  11-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

public class PlayingCard : MonoBehaviour
{
    private GameManager _gameManager;
    private Camera eventCamera;

    private XRReferenceImage referenceImage;
    private Sprite           cardImage;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;

        //> Sets up the canvas camera. Otherwise, the worldspace canvas doesn't work.
        eventCamera = FindObjectOfType<Camera>();
        if (eventCamera != null) {
            GetComponentInChildren<Canvas>().worldCamera = eventCamera;
            //Debug.Log("Found camera: " + eventCamera.name + "!");
        }

        //> Reads referenceImage of the ARTracker and fills cardImage with a corresponding sprite.
        if (GetComponent<ARTrackedImage>().referenceImage == null)
        {
            Debug.LogWarning("referenceImage is null.");
        }
        else
        {
            referenceImage = GetComponent<ARTrackedImage>().referenceImage;

            switch (referenceImage.name)
            {
                case "V8C1":
                    cardImage = _gameManager.PlayingCardList[1];
                    break;
                case "V8C2":
                    cardImage = _gameManager.PlayingCardList[2];
                    break;
                default:
                    cardImage = _gameManager.PlayingCardList[0];
                    Debug.LogWarning("ReferenceImage \"" + referenceImage.name + "\" has no cardImage assigned to it. Falling back to default.");
                    break;
            }

            Debug.Log("Displaying " + cardImage.name + " on " + referenceImage.name + ".");
        }

        //> Overwrites currently displayed sprite with new one from the cardImage variable.
        if (cardImage == null)
        {
            Debug.Log("cardImage is null.");
        }
        else
        {
            GetComponentInChildren<Image>().sprite = cardImage;
        }

    }

}
