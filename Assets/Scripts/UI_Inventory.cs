using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{


    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    public static UI_Inventory instance;


    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        itemSlotContainer = transform.Find("ItemsParent");
        instance = this;
    }

    public void RefreshInventoryItems() {   //Funcio per actualitzar els nombres del inventari a la UI
        int i = 0;
        foreach (Transform itemSlot in itemSlotContainer)
        {
             Text text = itemSlot.GetComponentInChildren<Text>();
            if (text == null) {
                Debug.Log("no es troba text");

            }
            else
            {
                text.text = inventory.items[i].amount.ToString();
            }
            i++;
        }

    }
}
