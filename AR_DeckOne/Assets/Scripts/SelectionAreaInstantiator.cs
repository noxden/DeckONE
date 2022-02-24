//----------------------------------------------------------------
// Darmstadt University of Applied Sciences, Expanded Realities
// Course: AR Art- and App-Development (Jan Alexander)
// Script by:    Daniel Heilmann (771144)
// Last changed:  22-02-22
// Legend: 
//    - "//>" indicates a summary for the following code.
//    - "//<" indicates a summary for the preceding code.
//----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAreaInstantiator : MonoBehaviour
{
    public DeckBuilder _deckBuilder;

    public GameObject columnLeft;
    public GameObject columnRight;

    public GameObject CardContainerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        List<Sprite> _AllCards = _deckBuilder.AllCards;
        GameObject targetColumn;

        for (int i = 0; i < _AllCards.Count; i++)
        {
            if (i % 2 == 0)
            {
                targetColumn = columnLeft;
                //left
            }
            else
            {
                targetColumn = columnRight;
                //right
            }

            CardContainerPrefab = new GameObject();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
