using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{
    public ARPlaneManager planeManager;

    public GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (ARPlane plane in eventArgs.added)
        {
            _gameManager.OnPlaneAdded(plane);
        }

        foreach (ARPlane plane in eventArgs.updated)
        {
            _gameManager.OnPlaneUpdated(plane);
        }

        foreach (ARPlane plane in eventArgs.removed)
        {
            _gameManager.OnPlaneRemoved(plane);
        }
    }
}
