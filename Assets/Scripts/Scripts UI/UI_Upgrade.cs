using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{

    GameObject torreUpgrade;
    public Text titol;
    // Start is called before the first frame update
    void Start()
    {
        titol.text = "Upgrade " + torreUpgrade.GetComponent<Turret>().nomTorre + "?";
        Debug.Log("Titol " + titol.text);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmpleTorreUpgrade(GameObject torre)
    {
        Debug.Log("Omple la torre " + torre.name);
        torreUpgrade = torre;

    }

    public void OnClickYes()
    {
        Debug.Log("Ha clickat yes");

        // Actualitza el q sigui i close
        Debug.Log("Actualitza torre " + torreUpgrade.name);

        torreUpgrade.GetComponent<Turret>().UpgradeTorre();
        this.gameObject.SetActive(false);
    }

    public void OnClickNo()
    {
        Debug.Log("Ha clickat no");
        this.gameObject.SetActive(false);
    }
}
