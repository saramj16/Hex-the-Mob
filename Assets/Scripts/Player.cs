using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_InGame uI_InGame;
    public UI_Torres uiTorres;
    public Tutorial tutorial;

    private Inventory inventory;
    void Awake()
    {
        inventory = new Inventory();
       // uiInventory.SetInventory(inventory);
        uI_InGame.SetInventory(inventory);
        uiTorres.SetInventory(inventory);
        tutorial.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
