using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item.Element element;
    public int quant;

    private Item item;

    private void Awake()
    {
        item = new Item { elem = element, amount = quant };
    }

    private void OnTriggerEnter(Collider other)
    {
        Agafa();
    }

    public void Agafa()
    {

        Inventory.instance.pickUp(item);
        UI_InGame.instance.RefreshInventoryItems();
        Destroy(this.gameObject);
    }

}
