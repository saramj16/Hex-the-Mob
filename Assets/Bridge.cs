using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public GameObject runa1;
    public GameObject runa2;
    public GameObject pont;
    public Item.Element element1;
    public int quantitat1;
    public Item.Element element2;
    public int quantitat2;

    // Start is called before the first frame update

    public void ReparaPont(Inventory inventari)
    {
        bool error = inventari.spendResources(element1, quantitat1, element2, quantitat2);
        if (error)
        {
          //  Debug.Log("Pont reparat");
            runa1.gameObject.SetActive(false);
            runa2.gameObject.SetActive(false);
            pont.gameObject.SetActive(true);
        } else
        {
          //  Debug.Log("No hem pogut arreglar el pont");
        }
        

    }
}
