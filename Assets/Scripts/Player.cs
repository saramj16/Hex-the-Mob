using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    public UI_Torres uiTorres;

    private Inventory inventory;
    void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiTorres.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
