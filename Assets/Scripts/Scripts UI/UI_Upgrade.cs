using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{

    GameObject torreUpgrade;
    public Text titol;

    GameObject personatge;

    public Inventory inventari;
    public UI_InGame inventory;
    // Start is called before the first frame update
    void Start()
    {
        titol.text = "Upgrade " + torreUpgrade.GetComponent<Turret>().nomTorre + "?";
        Debug.Log("Titol " + titol.text);

    }
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Cursor.visible = true;
    }

    public void OmpleTorreUpgrade(GameObject torre)
    {
        Debug.Log("Omple la torre " + torre.name);
        torreUpgrade = torre;

    }

    public void OmplePersonatge(GameObject g)
    {
        personatge = g;

    }
    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_InGame>().GetInventory();
        // Debug.Log("Inventari guarda't " + inventari);
    }

    public void OnClickYes()
    {
        Debug.Log("Ha clickat yes");

        // Actualitza el q sigui i close
        Debug.Log("Actualitza torre " + torreUpgrade.name);

        torreUpgrade.GetComponent<Turret>().UpgradeTorre();
        inventory.RefreshInventoryItems();
        UnityEngine.Cursor.visible = false;
        this.gameObject.SetActive(false);
        personatge.GetComponent<PlayerShoot>().ActivaCursor();
    }

    public void OnClickNo()
    {
        Debug.Log("Ha clickat no");
        UnityEngine.Cursor.visible = false;
        this.gameObject.SetActive(false);
        personatge.GetComponent<PlayerShoot>().ActivaCursor();
    }
}
