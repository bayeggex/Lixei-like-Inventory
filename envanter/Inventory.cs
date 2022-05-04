using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SCinventory playerInventory;
    public PlayerActions playerActions;
    InventoryUIcontroller InventoryU;
   

    bool isSwapping;
    int tempIndex;
    Slot tempSlot;
    
    public void currentItem(int index){
        if(playerInventory.inventoryslots[index].item){
           playerActions.SetItem(playerInventory.inventoryslots[index].item.itemPrefab);
        }
    }
    
    public void UseItem(){
        if(isSwapping == true){
           gameObject.GetComponent<karakter>().hunger += 10f;
           isSwapping = false; 
           playerInventory.DeleteItem(tempIndex);
           InventoryU.UpdateUı(); 
        }
    }
    
    
    public void DeleteItem(){
        if(isSwapping == true){
           playerInventory.DeleteItem(tempIndex);
           isSwapping = false; 
           InventoryU.UpdateUı(); 
        }
    }

    public void DropItem(){
        if(isSwapping == true){
            playerInventory.DropItem(tempIndex,gameObject.transform.position+Vector3.forward);
            isSwapping = false;
            InventoryU.UpdateUı();
        }
    }
    
    
    public void SwapItem(int index){
        if(isSwapping == false){
            tempIndex = index;
            tempSlot = playerInventory.inventoryslots[tempIndex];
            isSwapping = true;
        }
        else if(isSwapping == true){
            playerInventory.inventoryslots[tempIndex] = playerInventory.inventoryslots[index];
            playerInventory.inventoryslots[index] = tempSlot;
            isSwapping = false;
        }
        InventoryU.UpdateUı();

    }
    
    private void Start(){
        InventoryU = gameObject.GetComponent<InventoryUIcontroller>();
        InventoryU.UpdateUı();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("item")){
            playerInventory.Additem(other.gameObject.GetComponent<Item>().item);
            Destroy(other.gameObject);
            InventoryU.UpdateUı();
        }
        
    }
}
