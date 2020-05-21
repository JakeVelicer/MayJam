using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    public bool isCollected;
    public bool isEquipped;
    public bool isDropped;
    public string name;

    public GameObject playerHands;
    public Transform playerEquipCoord;

    public abstract void Interact(); //what happens whenever an object is interacted with

}
