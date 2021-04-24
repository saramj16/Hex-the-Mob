using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_InGame : MonoBehaviour
{

    public GameObject recursos;
    public GameObject torre;
    public GameObject gameManager;

    private Inventory inventory;

    public Text dies;
    public Text vida;

    public Image vidaTorre;
    public Image tempsDia;

    public static UI_InGame instance;
    // Start is called before the first frame update
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    void Awake()
    {
        //Debug.Log(itemSlotContainer);
        instance = this;
    }

    private void Update()
    {
        dies.text = gameManager.GetComponent<WaveManager>().nDia.ToString();
        vida.text = torre.GetComponent<Hexentrum>().vidaActual.ToString();
        vidaTorre.fillAmount = torre.GetComponent<Hexentrum>().vidaActual / torre.GetComponent<Hexentrum>().vidaMaxima;
        tempsDia.fillAmount = gameManager.GetComponent<WaveManager>().countdown / gameManager.GetComponent<WaveManager>().tempsDia;
    }


    void ActualitzaBarraVida()
    {
       
    }

    public void RefreshInventoryItems()
    {   //Funcio per actualitzar els nombres del inventari a la UI

        for(int i = 0; i < recursos.transform.childCount; i++) { 
            Text text = recursos.transform.GetChild(i).GetComponentInChildren<Text>();
            //Debug.Log("Recurs " + text.text);
            if (text == null)
            {
                Debug.Log("No es troba text");

            }
            else
            {
                //Debug.Log("Text " + text.text);
                //Debug.Log("Text inventari " + inventory.items[i].amount);

                text.text = inventory.items[i].amount.ToString();

            }

        }

    }
}
