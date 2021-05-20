using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UI_CarregaBales : MonoBehaviour
{

    public int bales;
    public GameObject quantitatElements;
    public Inventory inventari;

    public GameObject numBales;
    public GameObject quantitatsWater;
    public GameObject quantitatsEarth;
    public GameObject quantitatsAir;
    public GameObject quantitatsFire;

    public UI_InGame inventory;
    public GameObject cursor;
    public GameObject personatge;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CalculaBales();
        numBales.GetComponent<Text>().text = bales.ToString();

        quantitatElements.transform.GetChild(0).GetComponent<Text>().text = inventari.items[0].amount.ToString();
        quantitatElements.transform.GetChild(1).GetComponent<Text>().text = inventari.items[1].amount.ToString();
        quantitatElements.transform.GetChild(2).GetComponent<Text>().text = inventari.items[2].amount.ToString();
        quantitatElements.transform.GetChild(3).GetComponent<Text>().text = inventari.items[3].amount.ToString();

        cursor.SetActive(false);
        UnityEngine.Cursor.visible = true;

        //Aqui hem de fer PAUSE a la CAMERA
        camera.gameObject.GetComponent<CinemachineBrain>().enabled = false;
        inventory.gameObject.SetActive(false);
    }


    public void OnClikcCompraBalesAigua()
    {
        int q1 = int.Parse(quantitatsWater.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        
        bool error = inventari.GastaRecursosCompraBales(Item.Element.Water, q1);

        if (error == true)
        {
            //Debug.Log("Hi ha hagut un error");
            //Debug.Log("Gastem recursos");
            bales += int.Parse(quantitatsWater.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            inventory.RefreshInventoryItems();
        }

    }

    public void OnClikcCompraBalesTerra()
    {
        int q1 = int.Parse(quantitatsEarth.transform.GetChild(1).gameObject.GetComponent<Text>().text);

        bool error = inventari.GastaRecursosCompraBales(Item.Element.Earth, q1);

        if (error == true)
        {
            //Debug.Log("Hi ha hagut un error");
            Debug.Log("Gastem recursos");
            bales += int.Parse(quantitatsEarth.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            inventory.RefreshInventoryItems();
        }

    }

    public void OnClikcCompraBalesAire()
    {
        int q1 = int.Parse(quantitatsAir.transform.GetChild(1).gameObject.GetComponent<Text>().text);

        bool error = inventari.GastaRecursosCompraBales(Item.Element.Air, q1);

        if (error == true)
        {
            //Debug.Log("Hi ha hagut un error");
            Debug.Log("Gastem recursos");
            bales += int.Parse(quantitatsAir.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            inventory.RefreshInventoryItems();
        }

    }

    public void OnClikcCompraBalesFoc()
    {
        int q1 = int.Parse(quantitatsFire.transform.GetChild(1).gameObject.GetComponent<Text>().text);

        bool error = inventari.GastaRecursosCompraBales(Item.Element.Fire, q1);

        if (error == true)
        {
            //Debug.Log("Hi ha hagut un error");
            Debug.Log("Gastem recursos");
            bales += int.Parse(quantitatsFire.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            inventory.RefreshInventoryItems();
        }

    }





    public void OnClickClose()
    {
        inventory.gameObject.SetActive(true);
        cursor.SetActive(true);
        UnityEngine.Cursor.visible = false;
        camera.gameObject.GetComponent<CinemachineBrain>().enabled = true;
        personatge.GetComponent<PlayerShoot>().ActivaCursor();
        this.gameObject.SetActive(false);
    }

    public void SetInventory(Inventory i)
    {
        //Debug.Log("Fet");
        inventari = i;
    }
}
