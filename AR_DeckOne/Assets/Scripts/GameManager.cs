//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)  // Jonathan Kuchenbrod (770410)
// Last changed:  11-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using Lean.Touch;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public ARTrackedImageManager trackedImageManager;

    
    public List<Sprite> PlayingCardList;    //< Contains the sprites for all playing cards.


    public List<XRReferenceImage> ReferenceImageList;    


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

    private void Start()
    {
        
    
        IReferenceImageLibrary  refLib = trackedImageManager.referenceLibrary;

        int libLength = refLib.count;

        for (int i = 0; i < libLength; i++) 
        {
            ReferenceImageList.Add(refLib[i]);
            // index# -> the 2D image -> texture
            
            //Debug.Log(refLib[i].name);
            //Debug.Log("I count");
        }
    }

    // Touch Events
    public void onTap(LeanFinger finger)
    {
        Debug.Log($"{this.name} just registered a finger tap at {finger.ScreenPosition}!");
    }

    // Tracked Image Events
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