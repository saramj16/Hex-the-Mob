using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexAnim : MonoBehaviour
{
    public Animator at; //animador del prefab


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) { //IF per fer probes/////////////////////


            changeState(); //Crida funcio de obrir/tencar caixa


        }


    }

    //Funcio per canviar d'estat l'animacio de la caixa
    public void changeState() {
        at.SetTrigger("changeState"); //Trigger que canvia l'estat de la caixa
        at.SetBool("open", !at.GetBool("open")); //Invertim el seu estat del animator
        transform.GetChild(2).gameObject.SetActive(!at.GetBool("open")); //Agafem el 3r child, les particules, i les fem apareixer o desapareixer
                                                                         // depenent de si el baul s'obre o es tenca
    }


}
