using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapInteraction : MonoBehaviour
{
    [SerializeField] 
    private Camera mainCamera;

    [SerializeField]
    private LayerMask layerMask;

    private Image imageComponent;

    private bool isFullscreenCardShown = false;

    private void Start()
    {
        imageComponent = GetComponentInChildren<Image>();
        if (imageComponent != null)
        {
            imageComponent.enabled = false;
        }
        else
        {
            Debug.Log("HUD is missing an Image Component.");
        }
    }

    public void OnTap(Vector2 tapPosition)
    {
        if (isFullscreenCardShown)
        {
            hideFullscreenCard();
        }
        else
        {
            castRay(tapPosition);
        }
    }

    public void castRay(Vector2 tapPosition)
    {
        //Debug.Log($"{this.name} has initiated Raycast.");
        Ray ray = mainCamera.ScreenPointToRay(tapPosition);     //< Creates a ray that starts at the tapPosition.

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))       //< If the raycast hit a collider of the layerMask layer (in this case UI) ...
        {
            if (raycastHit.collider.GetComponent<Image>().sprite != null)                     //< and if this object even contains a sprite, ...
            {
                Sprite spriteOfHitObject = raycastHit.collider.GetComponent<Image>().sprite;  //< grab the sprite of the object hit.
                showFullscreenCard(spriteOfHitObject);                                        //< and display it
            }
        }
    }

    //> Displays "cardSprite" in full size on screen.
    private void showFullscreenCard(Sprite cardSprite)
    {
        imageComponent.enabled = true;
        imageComponent.sprite = cardSprite;
        imageComponent.SetNativeSize();
        isFullscreenCardShown = true;
    }

    //> Clears current sprite from screen and deactivates the imageComponent (technically our sprite container).
    private void hideFullscreenCard()
    {
        imageComponent.sprite = null;
        imageComponent.enabled = false;
        isFullscreenCardShown = false;
    }
}
