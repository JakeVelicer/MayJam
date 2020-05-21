using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public Dictionary<string, GameObject> inventory = new Dictionary<string, GameObject>();
    [Tooltip("Shows the contents of the Dictionary")] public List<GameObject> dictionaryContent;
    public bool isHittingObj; //detects if raycast is hitting object with InventoryItem_Behavior script. 
                              //Should be true ONLY if object has the InventoryItem_Behavior script
    [Tooltip("Gets InventoryItem_Behavior script from raycastHit object")] public InventoryItem_Behavior item;

    public string equippedObject;
    public GameObject lastEquipped;
    public int i = -1;
    public int lastIndex = -2;

    // Update is called once per frame
    void Update()
    {

        Debug.Log(dictionaryContent.Capacity);
        DropItem();
        //Adds items to Dictionary
        if (isHittingObj)
        {
            //gets the ItemIndex script that is attached to the object the raycast hits
            //item = hit.collider.GetComponent<InventoryItem_Behavior>(); 

            //if RC is hitting and player interacts, add object to List at the items index
            if (Input.GetKeyDown(KeyCode.E) && !item.isCollected && item != null)
            {
                item.Interact();
                inventory.Add(item.name, item.gameObject);
                dictionaryContent.Add(item.gameObject);
                //Debug.Log(item.name);
            }
        }

        NavigateInventory();
    }

    public void NavigateInventory()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            i++;
            //lastIndex++;
            if (i < dictionaryContent.Capacity)
            {
                //Debug.Log("Less than");
                EquippedItem(i);
            }
            if(i == dictionaryContent.Capacity)
            {
                Debug.Log(i + " == " + dictionaryContent.Capacity);
                i = 0;
                EquippedItem(i);
            }

        }
    }

    private void EquippedItem(int i)
    {
        UnequipItem();
        equippedObject = dictionaryContent[i].gameObject.name;
        
        //Debug.Log(equippedObject);

        GameObject.Find(equippedObject).GetComponent<InventoryItem_Behavior>().isEquipped = true;
        Debug.Log(dictionaryContent[i].GetComponent<InventoryItem_Behavior>().name);
        
        item.Interact();
    }
    private void UnequipItem()
    {
        if (i > 0)
        {
            lastEquipped = GameObject.Find(equippedObject);
            lastEquipped.GetComponent<InventoryItem_Behavior>().isEquipped = false;
            item.Interact();
        }
        if(lastIndex == 3)
        {
            lastEquipped = GameObject.Find(dictionaryContent[i].gameObject.name);
            lastEquipped.GetComponent<InventoryItem_Behavior>().isEquipped = false;
            item.Interact();
        }
    }

    public void DropItem()
    {
        if(Input.GetKeyDown(KeyCode.E) && item.isEquipped == true)
        {
            //lastEquipped = GameObject.Find(equippedObject);
            //GameObject.Find(equippedObject).GetComponent<InventoryItem_Behavior>().isEquipped = false;
            GameObject.Find(equippedObject).GetComponent<InventoryItem_Behavior>().isDropped = true;
            item.Interact();
        }
        else if(item.isEquipped == true && item != null)
        {
            GameObject.Find(equippedObject).GetComponent<InventoryItem_Behavior>().isDropped = false;
        }
    }
}
