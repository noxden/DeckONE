//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Jan Alexander, Daniel Heilmann (771144)
// Last changed:  22-02-22
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//> Because of these, we don't need to do a null check before accessing them, because they are more likely to be present
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class ActionButton : MonoBehaviour, IPointerClickHandler    //< This class also implements the "IPointerClickHandler" protocol (required for button events)
{
    public UnityEvent onButtonPressed;

    private BoxCollider2D _boxCollider2D;
    private RectTransform _rectTransform;

    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rectTransform = GetComponent<RectTransform>();

        _boxCollider2D.isTrigger = true;
        _boxCollider2D.size = new Vector2(_rectTransform.rect.width, _rectTransform.rect.height);
    }

    // Event Handlers
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log($"{this.name} has been pressed. Executing OnPointerClick now.");
        onButtonPressed.Invoke();
    }
}
