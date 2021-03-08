﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RepareBridge : MonoBehaviour
{
    GameObject bridge = null;
    public Text titol;
    public Inventory inventari;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = true;
        titol.text = "Repare " + bridge.name + "?"; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmpleBridge(GameObject b)
    {
      //  Debug.Log("Omple el bridge");
        bridge = b;
    }

    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_Inventory>().GetInventory();
       // Debug.Log("Inventari guarda't " + inventari);
    }

    public void OnClickYes()
    {
      //  Debug.Log("Ha clickat yes");
      
        bridge.GetComponent<Bridge>().ReparaPont(inventari);

        // Actualitza el q sigui i close
      //  Debug.Log("Repara bridge " + bridge.name);
        UnityEngine.Cursor.visible = false;
        this.gameObject.SetActive(false);
    }

    public void OnClickNo()
    {
       // Debug.Log("Ha clickat no");
        this.gameObject.SetActive(false);
        UnityEngine.Cursor.visible = false;
    }
}
