using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableExample : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void ActivateInteraction()
    {
        if (GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;            
        }
        else if (GetComponent<MeshRenderer>().enabled == false)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

    }

}
