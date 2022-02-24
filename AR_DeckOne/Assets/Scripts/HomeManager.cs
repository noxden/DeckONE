//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Jan Alexander, Daniel Heilmann (771144)
// Last changed:  21-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

/*
#if UNITY_IOS
using NativeCameraNamespace;
#endif
*/

public class HomeManager : MonoBehaviour
{
    public ARSession arSession;

    private bool _didTriggerCameraPermissionRequestAtStart;

    private void Awake()
    {
        arSession.gameObject.SetActive(false);

        // Performance Settings
        /*
        int width = Screen.width;
        int height = Screen.height;
        Screen.SetResolution(width / 2, height / 2, false);
        */
        
        Application.targetFrameRate = 30;

        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = 300;
    }

    public void Start()
    {
        _didTriggerCameraPermissionRequestAtStart = StorageManager.didTriggerCameraPermissionRequest;
        print($"_didTriggerCameraPermissionRequestAtStart {_didTriggerCameraPermissionRequestAtStart}");
        print($"didShowTutorial {StorageManager.didShowTutorial}");

        if (!StorageManager.didShowTutorial)
        {
            ShowTutorial();
        }
        /*
        else if (!_didTriggerCameraPermissionRequestAtStart)
        {
            StartCoroutine(StartGameWhenCameraPermissionIsGranted());
        }
        */
        
    }

    // Event Handlers
    public void OnStartGameButtonPressed()
    {
        print("Unity: OnStartGameButtonPressed");
        if (IsCameraPermissionGranted())
        {
            StartGame();
        }
        else
        {
            TriggerPermissionRequest();
        }
    }

    // Private Helpers
    private IEnumerator StartGameWhenCameraPermissionIsGranted()
    {
        
        if (_didTriggerCameraPermissionRequestAtStart)
        {
            yield return null;
        }
        

        print($"CheckIfCameraPermissionIsGranted {IsCameraPermissionGranted()}");

        while (!IsCameraPermissionGranted())
        {
            print("Checking if camera permission is granted");
            yield return new WaitForSeconds(.5f);
        }

        if (IsCameraPermissionGranted())
            StartGame();
    }

    private void TriggerPermissionRequest()
    {
#if UNITY_ANDROID
        Permission.RequestUserPermission(Permission.Camera);
#endif
        //StorageManager.SetCameraPermissionRequestAsTriggered();
    }

    private void StartGame()
    {
        SceneTransitionManager.LoadScene(Scene.Game);
    }

    private void ShowTutorial()
    {
        SceneTransitionManager.LoadScene(Scene.Tutorial);
    }

    private bool IsCameraPermissionGranted()
    {
#if UNITY_ANDROID
        Debug.Log($"Camera permissions are {Permission.HasUserAuthorizedPermission(Permission.Camera)}");
        return Permission.HasUserAuthorizedPermission(Permission.Camera);


        /*
#if UNITY_IOS
        return NativeCamera.CheckPermission() == NativeCamera.Permission.Granted;
#endif
        */
#else
        print("Warning: IsCameraPermissonGranted() fell through.");
        return false;
#endif
    }

    /* Further readings about permission-requests and -callbacks:
     * https://docs.unity3d.com/ScriptReference/Application.RequestUserAuthorization.html
     * https://gamedev.stackexchange.com/questions/175751/how-to-get-android-permission-call-back-in-unity
     */
}
