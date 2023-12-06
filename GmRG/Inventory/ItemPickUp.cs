using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactble
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            
            Debug.Log("Picking up " + item.name);
            playerInventory.CarrotCollected();

            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
                Destroy(gameObject);

        }
    }
}
