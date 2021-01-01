using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    Inventory inventari;
    GameObject jugador;
    Casella[] caselles;
    public GameObject[] c;
    private void Start()
    {
        if (c == null)
        {
            c = GameObject.FindGameObjectsWithTag("Ground");

            for (int i = 0; i < c.Length; i++)
            {
                caselles[i].OmpleCasella(c[i]);
            }
        }
        
        


    }
}

