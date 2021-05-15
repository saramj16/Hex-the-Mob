using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CarregaBales : MonoBehaviour
{

    public int bales;
    public GameObject quantitatElements;
    public Inventory inventari;

    public GameObject numBales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculaBales();
        numBales.GetComponent<Text>().text = bales.ToString();


       /* cursor.SetActive(false);
        UnityEngine.Cursor.visible = true;

        //Aqui hem de fer PAUSE a la CAMERA
        camera.gameObject.GetComponent<CinemachineBrain>().enabled = false;
        inventory.gameObject.SetActive(false);*/
    }

    private void CalculaBales()
    {
        int q1 = int.Parse(quantitatElements.transform.GetChild(0).GetComponent<Text>().text);
        int q2 = int.Parse(quantitatElements.transform.GetChild(1).GetComponent<Text>().text);
        int q3 = int.Parse(quantitatElements.transform.GetChild(2).GetComponent<Text>().text);
        int q4 = int.Parse(quantitatElements.transform.GetChild(3).GetComponent<Text>().text);

        bales = q1 * 5 + q2 * 3 + q3 * 2 + q4;
    }
    public void CompraBales()
    {
        int q1 = int.Parse(quantitatElements.transform.GetChild(0).GetComponent<Text>().text);
        int q2 = int.Parse(quantitatElements.transform.GetChild(1).GetComponent<Text>().text);
        int q3 = int.Parse(quantitatElements.transform.GetChild(2).GetComponent<Text>().text);
        int q4 = int.Parse(quantitatElements.transform.GetChild(3).GetComponent<Text>().text);
        inventari.GastaRecursosCompraBales(Item.Element.Water, q1, Item.Element.Earth, q2, Item.Element.Air, q3, Item.Element.Fire, q4);

    }

    public void OnClickMes(GameObject quantitat)
    {
        int q = int.Parse(quantitat.GetComponent<Text>().text);

        q++;

        quantitat.GetComponent<Text>().text = q.ToString();

    }

    public void OnClickMenys(GameObject quantitat)
    {
        int q = int.Parse(quantitat.GetComponent<Text>().text);

        if(q > 0)
        {
            q--;
        }

        quantitat.GetComponent<Text>().text = q.ToString();
    }

    public void OnClickClose()
    {
        this.gameObject.SetActive(false);
    }

    public void SetInventory(Inventory i)
    {
        inventari = i;
    }
}
