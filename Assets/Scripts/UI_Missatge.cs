using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Missatge : MonoBehaviour
{
    public bool option = false;

    public bool hanClickat = false;


    public void OnClikYes()
    {
        option = true;
        hanClickat = true;
        Debug.Log("Han clickat SI");
        this.gameObject.SetActive(false);
        //Hem de posar la torreta des d'aqui
        //UI_Torre.SetActive(true);
    }



    public void OnClikNo()
    {
        option = false;
        hanClickat = true;
        Debug.Log("Han clickat NO");

        this.gameObject.SetActive(false);
    }

    public void click()
    {
        hanClickat = false;
    }
}
