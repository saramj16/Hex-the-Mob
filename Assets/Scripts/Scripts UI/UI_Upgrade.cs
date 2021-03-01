using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{

    GameObject torreUpgrade = null;
    public Text titol;
    // Start is called before the first frame update
    void Start()
    {
   
        titol.text = "Upgrade " + torreUpgrade.GetComponent<Turret>().nomTorre + "?";

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmpleTorreUpgrade(GameObject torre)
    {
        Debug.Log("Omple la torre");
        torreUpgrade = torre;
    }

    public void OnClickYes()
    {
        Debug.Log("Ha clickat yes");

        // Actualitza el q sigui i close
        Debug.Log("Actualitza torre " + torreUpgrade.name);

        torreUpgrade.GetComponent<Turret>().UpgradeTorre();
    }

    public void OnClickNo()
    {
        Debug.Log("Ha clickat no");
        this.gameObject.SetActive(false);
    }
}
