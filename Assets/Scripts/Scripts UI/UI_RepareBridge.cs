using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RepareBridge : MonoBehaviour
{
    GameObject bridge = null;
    public Text titol;
    // Start is called before the first frame update
    void Start()
    {
        titol.text = "Repare " + bridge.name + "?"; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmpleBridge(GameObject b)
    {
        Debug.Log("Omple el bridge");
        bridge = b;
    }

    public void OnClickYes()
    {
        Debug.Log("Ha clickat yes");

        // Actualitza el q sigui i close
        Debug.Log("Repara bridge " + bridge.name);
    }

    public void OnClickNo()
    {
        Debug.Log("Ha clickat no");
        this.gameObject.SetActive(false);
    }
}
