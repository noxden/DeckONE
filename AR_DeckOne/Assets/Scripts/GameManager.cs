using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameManager gameManager;

    public static GameManager instance
    {
        get { return FindObjectOfType<GameManager>(); }
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