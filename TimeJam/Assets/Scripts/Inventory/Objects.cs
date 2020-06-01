using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objects : Interactable
{
    public bool isCollected;
    public bool isEquipped;
    public string name;

    public Collider collider;
    public Rigidbody rigidBody;

    public abstract void Use(); // What happens whenever an object is interacted with while being held

    public override void ActivateInteraction()
    {

    }
    
    public void PickUp(Transform playerHand)
    {
        isCollected = true;
        transform.parent = playerHand;
        transform.position = playerHand.position;
        if (collider != null)
        {
            collider.enabled = false;
        }
        if (rigidBody != null)
        {
            rigidBody.isKinematic = true;
            rigidBody.useGravity = false;
        }
    }

    public void Drop()
    {
        transform.parent = null;
        if (collider != null)
        {
            collider.enabled = true;
        }
        if (rigidBody != null)
        {
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
        }
        isCollected = false;
    }

}
