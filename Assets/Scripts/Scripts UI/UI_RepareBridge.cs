using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RepareBridge : MonoBehaviour
{
    GameObject bridge = null;
    public Text titol;
    public Text cost;
    public Image recurs;
    public Sprite aigua;
    public Sprite foc;
    public Sprite aire;
    public Sprite terra;
    public Inventory inventari;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = true;
        titol.text = "Repare " + bridge.name + "?"; ;
    }

    public void CanviaNom(string nom)
    {
        titol.text = "Repare " + nom + "?"; ;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmpleBridge(GameObject b)
    {
      //  Debug.Log("Omple el bridge");
        bridge = b;

        cost.text = b.GetComponent<Bridge>().quantitat1.ToString();

        switch (b.GetComponent<Bridge>().element1){
            case Item.Element.Air:
                recurs.sprite = aire;
                break;
            case Item.Element.Water:
                recurs.sprite = aigua;
                break;
            case Item.Element.Earth:
                recurs.sprite = terra;
                break;
            case Item.Element.Fire:
                recurs.sprite = foc;
                break;
        }
    }

    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_InGame>().GetInventory();
       // Debug.Log("Inventari guarda't " + inventari);
    }

    public void OnClickYes()
    {
      //  Debug.Log("Ha clickat yes");
      
        bridge.GetComponent<Bridge>().ReparaPont(inventari);
        bridge.GetComponent<Bridge>().PontArreglat();

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
