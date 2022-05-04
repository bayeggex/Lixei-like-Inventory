using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIcontroller : MonoBehaviour
{
    public List<SlotUı> uilist = new List<SlotUı>();
    Inventory userInventory;

    private void Start() {
        userInventory = gameObject.GetComponent<Inventory>();
        UpdateUı();

    }

    public void UpdateUı(){
        for(int i = 0; i < uilist.Count; i++){
            if(userInventory.playerInventory.inventoryslots[i].itemCount > 0){
                uilist[i].itemImage.sprite = userInventory.playerInventory.inventoryslots[i].item.itemIcon;
                if(userInventory.playerInventory.inventoryslots[i].item.canStackable == true){
                    uilist[i].itemCountText.gameObject.SetActive(true);
                    uilist[i].itemCountText.text = userInventory.playerInventory.inventoryslots[i].itemCount.ToString();
                }
                else{
                    uilist[i].itemCountText.gameObject.SetActive(false);

                }
            }
            else{
                uilist[i].itemImage.sprite = null;
                uilist[i].itemCountText.gameObject.SetActive(false);
            }
            
        }

    }
}
