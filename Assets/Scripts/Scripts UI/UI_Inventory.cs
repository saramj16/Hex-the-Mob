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

    public Inventory GetInventory()
    {
        return inventory;
    }

    // Start is called before the first frame update
    void Awake()
    {
        itemSlotContainer = transform.Find("ItemsParent");
        //Debug.Log(itemSlotContainer);
        instance = this;
    }

    public void RefreshInventoryItems() {   //Funcio per actualitzar els nombres del inventari a la UI
        int i = 0;
        foreach (Transform itemSlot in itemSlotContainer)
        {
            Text text = itemSlot.GetComponentInChildren<Text>();
            if (text == null) {
                Debug.Log("No es troba text");

            }
            else
            {
                //Debug.Log("Text " + text.text);
                //Debug.Log("Text inventari " + inventory.items[i].amount);
                text.text = inventory.items[i].amount.ToString();
            }
            i++;
        }

    }
}
