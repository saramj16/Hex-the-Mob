using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public SpawnResources spawnResources;
    public GameObject runa1;
    public GameObject runa2;
    public GameObject pont;
    public Item.Element element1;
    public int quantitat1;
    public Item.Element element2;
    public int quantitat2;

    public GameObject colliderPont;
    public bool arreglat = false;

    public Item.Element zonaDesbloquejada;

    // Start is called before the first frame update

    public bool ReparaPont(Inventory inventari)
    {
        bool error = inventari.spendResources(element1, quantitat1, element2, quantitat2);
        if (error)
        {
          //  Debug.Log("Pont reparat");
            runa1.gameObject.SetActive(false);
            runa2.gameObject.SetActive(false);
            pont.gameObject.SetActive(true);
            colliderPont.SetActive(false);
        } else
        {
           Debug.Log("No hem pogut arreglar el pont " + error);
        }

        return error;

    }

    public void PontArreglat()
    {
        arreglat = true;

        switch (zonaDesbloquejada)
        {
            case Item.Element.Air:
                spawnResources.zonaAire = true;
                break;
            case Item.Element.Water:
                spawnResources.zonaAigua = true;
                break;
            case Item.Element.Earth:
                spawnResources.zonaTerra = true;
                break;
            case Item.Element.Fire:
                spawnResources.zonaFoc = true;
                break;
        }

 

    }
}
