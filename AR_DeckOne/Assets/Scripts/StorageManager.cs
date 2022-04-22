//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Jan Alexander, Daniel Heilmann (771144)
// Last changed:  22-02-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager
{
    public static bool didShowTutorial
    {
        get
        {
            return PlayerPrefs.GetInt(PlayerPrefsKey.didShowTutorial, 0) == 1;  //< "PlayerPrefsKey.didShowTutorial" is just a String variable (see line 49)
        }
    }


    public static void SetTutorialAsShown()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey.didShowTutorial, 1);
    }
    public static bool didTriggerCameraPermissionRequest
    {
        get
        {
            return PlayerPrefs.GetInt(PlayerPrefsKey.didTriggerCameraPermissionRequest, 0) == 1;
        }
    }

    public static void SetCameraPermissionRequestAsTriggered()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey.didTriggerCameraPermissionRequest, 1);
    }

    //> Additional info:
    //  PlayerPrefs also supports the following functions:
    //  PlayerPrefs.SetFloat()
    //  PlayerPrefs.SetString()
    //<
}

public class PlayerPrefsKey
{
    public static string didShowTutorial = "didShowTutorial";
    public static string didTriggerCameraPermissionRequest = "didTriggerCameraPermissionRequest";
}