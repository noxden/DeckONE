//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Jan Alexander, Daniel Heilmann (771144)
// Last changed:  22-02-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene   //< This could also be positioned outside of the SceneTransitionManager, thereby shorting every reference to it -> "Scene.Tutorial" instead of "SceneTransitionManager.Scene.Tutorial"
{
    Home, Tutorial, Credits, Game, OpenSettings, PreGame
}

public class SceneTransitionManager
{
    // Public Methods
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadSceneAsync(SceneName(scene));
    }

    // Helper Methods
    private static string SceneName(Scene scene)
    {
        switch (scene)
        {
            case Scene.Home:
                return "Home";
            case Scene.Game:
                return "Game";
            case Scene.Tutorial:
                return "Tutorial";
            case Scene.Credits:
                return "Credits";
            case Scene.OpenSettings:
                return "OpenSettings";
            case Scene.PreGame:
                return "PreGame";
        }
        return "";
    }
}