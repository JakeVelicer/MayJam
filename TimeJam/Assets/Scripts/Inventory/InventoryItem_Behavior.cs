using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem_Behavior : Objects
{
    //public PlayerInventory playIn;

    public override void Interact()
    {
        if(!isCollected)
            isCollected = true;
        //Debug.Log("Item Added to Inventory");

        if (this.isEquipped)
        {
            this.gameObject.SetActive(true);
            Debug.Log(this.name + " is equipped");
            this.transform.position = playerEquipCoord.transform.position;
            this.transform.parent = playerHands.transform;
        }
        else if (!isEquipped)
        {
            this.gameObject.SetActive(false);
        }

        if (isDropped)
        {
            this.transform.parent = null;
        }
    }
}
