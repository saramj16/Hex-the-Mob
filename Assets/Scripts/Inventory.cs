
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public List<Item> items;

    public static Inventory instance; 

    public Inventory() {
        items = new List<Item>();
        AddItem(new Item {elem = Item.Element.Water, amount = 0 });
        AddItem(new Item { elem = Item.Element.Fire, amount = 0 });
        AddItem(new Item { elem = Item.Element.Earth, amount = 0 });
        AddItem(new Item { elem = Item.Element.Air, amount = 0 });
        instance = this;
    }

    public void AddItem(Item item) {
        items.Add(item);
    }

    public List<Item> GetItemList() {
        return items;
    }

    public void pickUp(Item item) {
       
        int i = elemPos(item.elem);
        items[i].amount += item.amount;
        //Debug.Log("Element: " + items[i].elem + "   Amount: " + items[i].amount);
        
    }

    public int elemPos(Item.Element e) {
        for (int i = 0; i < items.Count; i++)
        {
            if (e == items[i].elem) {
                return i;
            }
        }
        Debug.Log("Element no existent");
        return 0;

    }

    public bool spendResources(Item.Element item1, int q1, Item.Element item2, int q2)
    {
        int i = elemPos(item1);
        int j = elemPos(item2);
        //Debug.Log("Element: " + items[i].elem + "   Amount: " + items[i].amount);
        //Debug.Log("Element: " + items[j].elem + "   Amount: " + items[j].amount);
        if (items[i].amount == 0 || items[j].amount == 0 || items[i].amount - q1 < 0 || items[j].amount - q2 < 0)
        {
            return false;
        } else
        {
            //Debug.Log("Restem elements, return true");

            items[i].amount -= q1;
            //Debug.Log("Element: " + items[i].elem + "   Amount: " + items[i].amount);


            items[j].amount -= q2;
            //Debug.Log("Element: " + items[j].elem + "   Amount: " + items[j].amount);
            return true;
        }
    }

    


}
