//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  12-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.Events;

public class TouchManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnTap;

    void OnEnable()
    {
        Debug.Log("Touch Input has been enabled.");
        LeanTouch.OnFingerTap += HandleFingerTap;
        LeanTouch.OnFingerSwipe += HandleFingerSwipe;
    }

    void OnDisable()
    {
        Debug.Log("Touch Input has been disabled.");
        LeanTouch.OnFingerTap -= HandleFingerTap;
        LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        //print($"Finger tap at {finger.ScreenPosition}");
        OnTap.Invoke(finger.ScreenPosition);
    }

    private void HandleFingerSwipe(LeanFinger finger)
    {
        print($"Swipe at {finger.ScreenPosition}");
    }
}