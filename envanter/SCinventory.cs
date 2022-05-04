using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")]

public class SCinventory : ScriptableObject
{

    public List<Slot> inventoryslots = new List<Slot>();
    int stacklimit = 4;

    
    
    public void DeleteItem(int index){
        inventoryslots[index].isFull = false;
        inventoryslots[index].itemCount = 0;
        inventoryslots[index].item = null;

    }

    public void UseItem(int index){
        inventoryslots[index].isFull = false;
        inventoryslots[index].itemCount = 0;
        inventoryslots[index].item = null;


    }
    
    public void DropItem(int index,Vector3 position){
       
        for(int i = 0; i < inventoryslots[index].itemCount; i++){
          
          GameObject tempItem = Instantiate(inventoryslots[index].item.itemPrefab);
          tempItem.transform.position = position;
        }
        DeleteItem(index);
        

    }
     
    public bool Additem(SCitem item){
        foreach(Slot slot in inventoryslots){
            if(slot.item == item){
                if(slot.item.canStackable){
                    if(slot.itemCount < stacklimit){
                        slot.itemCount++; 
                        if(slot.itemCount >= stacklimit){
                            slot.isFull = true;
                        }
                        return true;

                    }
                }
            }
            else if(slot.itemCount == 0){
                slot.AdditemToSlot(item);
                return true;
            
            }





        }
        return   false;
      
        
    }
    
     

    
}


[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public SCitem item;
    
    public void AdditemToSlot(SCitem item){
        this.item = item;
        if(item.canStackable == false){
            isFull = true;
        }
        itemCount++;

    }

}
