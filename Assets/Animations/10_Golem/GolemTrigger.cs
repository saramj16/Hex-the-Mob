using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemTrigger : MonoBehaviour
{
    public Animator at; //Animador del prefab
    public ParticleSystem dust; //Particules de pols


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) { ///////////////IF de PROBA per ferr TESTS

            at.SetTrigger("DoPunch"); // Funcio que activa l'animacio de cop de puny, per quan s'activi el golem

        }
    }

    void DustTrigger()
    { //Funcio que s'activa durant l'animacio per treure l'efecte de pols
        dust.Play();
    }
}
