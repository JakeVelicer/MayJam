using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject[] inventory;
    public GameObject equippedObject;
    public GameObject lastEquipped;
    public int selectedIndex = 0;

    // Update is called once per frame
    void Update()
    {
        NavigateInventory();
    }

    public void NavigateInventory()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedIndex++;
            if(selectedIndex < inventory.Length - 1)
            {
                if(inventory[selectedIndex] != null)
                {
                    EquipItem();
                }
                else
                {
                    selectedIndex--;
                }
            }
            if(selectedIndex >= inventory.Length - 1)
            {
                if(inventory[0] != null)
                {
                    selectedIndex = 0;
                    EquipItem();
                }
                else
                {
                    selectedIndex--;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedIndex--;
            if(selectedIndex > 0)
            {
                if(inventory[selectedIndex] != null)
                {
                    EquipItem();
                }
                else
                {
                    selectedIndex++;
                }
            }
            if(selectedIndex <= 0)
            {
                if(inventory[inventory.Length - 1] != null)
                {
                    selectedIndex = inventory.Length - 1;
                    EquipItem();
                }
                else
                {
                    selectedIndex++;
                }
            }
        }
    }

    public void PickUpItem(GameObject itemToPickUp)
    {
        if (inventory[0] == null)
        {
            inventory[0] = itemToPickUp;
            EquipItem();
            selectedIndex = 0;
            Debug.Log(inventory[0]);
        }
        else
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null && !itemToPickUp.GetComponent<InventoryItem_Behavior>().isCollected)
                {
                    inventory[i] = itemToPickUp;
                    EquipItem();
                    Debug.Log(inventory[i]);
                    break;
                }
            }
        }
    }

    private void EquipItem()
    {
        if (equippedObject != null)
        {
            UnequipItem(equippedObject);
            Debug.Log(equippedObject);
        }
        equippedObject = inventory[selectedIndex];
        equippedObject.SetActive(true);
        equippedObject.GetComponent<InventoryItem_Behavior>().isEquipped = true;
    }

    private void UnequipItem(GameObject lastObjectSelected)
    {
        lastEquipped = lastObjectSelected;
        lastEquipped.GetComponent<InventoryItem_Behavior>().isEquipped = false;
        lastEquipped.SetActive(false);
    }

}
