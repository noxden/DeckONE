using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCard : MonoBehaviour
{
    private Camera eventCamera;

    [SerializeField]
    public List<Sprite> PlayingCardList;

    // Start is called before the first frame update
    void Start()
    {
        eventCamera = (Camera)FindObjectOfType<Camera>();
        if (eventCamera != null) {
            Debug.Log("Found camera: " + eventCamera.name + "!");
            GetComponent<Canvas>().worldCamera = eventCamera;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
