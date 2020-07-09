using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBehavior : MonoBehaviour
{
    public float rayCastLength = 6;
    public Transform hand;
    private RaycastHit hit;
    private GameObject selectedObject;
    private PlayerInput playerInput;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInventory = GetComponent<PlayerInventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.playerControlInput.Player.Interact.performed += ctx => InteractButton();
    }

    // Update is called once per frame
    void Update()
    {
        var handRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(handRay, out hit, rayCastLength))
        {
            if (hit.transform.gameObject.GetComponent<Interactable>())
            {
                selectedObject = hit.transform.gameObject;
            }
            else
            {
                selectedObject = null;
            }
            Debug.DrawLine(handRay.origin, hit.point);
        }
        else
        {
            selectedObject = null;
        }
    }

    public void InteractButton()
    {
        if (selectedObject != null)
        {
            if (selectedObject.GetComponent<Interactable>().canPickUp)
            {
                selectedObject.GetComponent<InventoryItem_Behavior>().PickUp(hand);
                playerInventory.PickUpItem(selectedObject);
                selectedObject = null;
            }
            else
            {
                selectedObject.GetComponent<Interactable>().ActivateInteraction();
            }
        }
    }
}
