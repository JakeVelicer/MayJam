using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool canPickUp;
    public bool canUseObject;
    public abstract void ActivateInteraction();
}
