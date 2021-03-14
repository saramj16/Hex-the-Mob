using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapTrigger : MonoBehaviour
{
    public Animator at; //Animador del prefab
    public ParticleSystem dust; //Particules de pols



    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.P)) { ///////////////IF de PROBA per ferr TESTS

            at.SetTrigger("BiteNow"); // Funcio que activa l'animacio de mossegar, per quan s'activi la trampa

        }*/
    }

    void DustTrigger() { //Funcio que s'activa durant l'animacio per treure l'efecte de pols
        dust.Play(); 
    }

    public void ActivaTorre()
    {
        Debug.Log("Activem torre");
        at.SetTrigger("BiteNow");
    }
}
