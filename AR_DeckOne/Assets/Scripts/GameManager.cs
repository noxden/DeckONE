//----------------------------------------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities, AR Art- and App-Development
// Script by:    Daniel Heilmann (771144)
// Last changed:  10-02-22
//----------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameManager gameManager;
    public static GameManager Instance { set; get; }

    private void Awake()
    {
        if (Instance == null)   //with this if-structure it is IMPOSSIBLE to create more than one instance
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // referring to the gameObject, this singleton script (class) is attached to
        }
        else
        {
            Destroy(this.gameObject);   //if you somehow still get to create a new singleton gameobject regardless, destroy the new one
        }
    }

    public void OnTrackedImageAdded(ARTrackedImage trackedImage)
    {
        print($"{trackedImage.referenceImage.name} has been added.");
    }
    public void OnTrackedImageUpdated(ARTrackedImage trackedImage)
    {
        print($"{trackedImage.referenceImage.name} has been changed.");
    }
    public void OnTrackedImageRemoved(ARTrackedImage trackedImage)
    {
        print($"{trackedImage.referenceImage.name} has been removed.");
    }


    public void OnPlaneAdded(ARPlane plane)
    {
        print($"Plane with ID {plane.trackableId} has been added.");
    }

    public void OnPlaneUpdated(ARPlane plane)
    {
        print($"Plane with ID {plane.trackableId} has been added.");
    }

    public void OnPlaneRemoved(ARPlane plane)
    {
        print($"Plane with ID {plane.trackableId} has been added.");
    }

}