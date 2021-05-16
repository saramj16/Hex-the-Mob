using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item.Element element;
    public int quant;
    public AudioSource pickSound;

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
        AudioSource.PlayClipAtPoint(pickSound.clip, this.gameObject.transform.position, 0.3f);
        Destroy(this.gameObject);
    }

}
