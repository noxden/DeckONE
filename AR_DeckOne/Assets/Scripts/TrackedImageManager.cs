using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;

public class TrackedImageManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    public UnityEvent<ARTrackedImage> OnTrackedImageAdded;
    public UnityEvent<ARTrackedImage> OnTrackedImageUpdated;
    public UnityEvent<ARTrackedImage> OnTrackedImageRemoved;

    public GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void OnEnable()
    {
        Debug.Log("Object has been enabled.");
        trackedImageManager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        Debug.Log("Object has been enabled.");
        trackedImageManager.trackedImagesChanged -= OnChanged;
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            //print($"{trackedImage.referenceImage.name} has been added.");
            //OnTrackedImageAdded.Invoke(trackedImage);
            _gameManager.OnTrackedImageAdded(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            //print($"{trackedImage.referenceImage.name} has been updated.");
            //if (trackedImage.trackingState == ARTrackedImage.trackingState.Limited) ...
            //OnTrackedImageUpdated.Invoke(trackedImage);
            _gameManager.OnTrackedImageUpdated(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            //print($"{trackedImage.referenceImage.name} has been removed.");
            //OnTrackedImageRemoved.Invoke(trackedImage);
            _gameManager.OnTrackedImageRemoved(trackedImage);
        }

    }

}
