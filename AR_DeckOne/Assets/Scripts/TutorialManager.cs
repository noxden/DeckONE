//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Jan Alexander, Daniel Heilmann (771144)
// Last changed:  22-02-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;    //< Is very sensitive to changes in folder structure

public class TutorialManager : MonoBehaviour
{
    /* No localization implemented right now 
    public Text slide01Headline;
    public Text slide02Headline;
    public Text slide03Headline;
    public Text slide04Headline;
    public Text slide05Headline;
    */
    public SimpleScrollSnap simpleScrollSnap;
    public int changeSceneOnPanelIndex = 4;    //< Because simpleScrollSnap.CenteredPanel starts at 0

    public Scene currentScene;
    public Scene sceneToLoad;

    public void Start()
    {
        Application.targetFrameRate = 90;
        //LocalizeText();
    }

    // Simple Scroll Snap Events
    public void OnPanelChanged()
    {
        int selectedPanel = simpleScrollSnap.CenteredPanel;
        print($"Changed to panel number {selectedPanel}");

        if (selectedPanel == changeSceneOnPanelIndex)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        switch (currentScene)
        {
            case Scene.Tutorial:
                StorageManager.SetTutorialAsShown();
                break;
            default:
                break;
        }
        SceneTransitionManager.LoadScene(sceneToLoad);
    }
    // Helper Methods
    private void LocalizeText()
    {
        /*
        slide01Headline.text = Localization.StringFor(Localization.Key.TutorialSlide01Headline);
        slide02Headline.text = Localization.StringFor(Localization.Key.TutorialSlide02Headline);
        slide03Headline.text = Localization.StringFor(Localization.Key.TutorialSlide03Headline);
        slide04Headline.text = Localization.StringFor(Localization.Key.TutorialSlide04Headline);
        slide05Headline.text = Localization.StringFor(Localization.Key.TutorialSlide05Headline);
        */
    }
}