﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosarTorretes : MonoBehaviour
{

    public float distancia = 1;
  
    public GameObject UI_Missatge;
    public GameObject UI_torres;
    public GameObject inventari;
    public GameObject UI_Upgrade;
    public GameObject UI_RepareBridge;

    private bool improveWay;
    private bool improveGround;
    private GameObject terrenyTorre;
    // Start is called before the first frame update
    void Start()
    {
        improveGround = false;
        improveWay = false;
        terrenyTorre = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            
            Vector3 position = transform.position;

            position.y = 0;

            GameObject casella = buscarCasella(position);
            GameObject way = buscarWay(position);

            if (!improveGround && !improveWay)
            {
                UI_torres.GetComponent<UI_Torres>().guardaPosition(casella, way);
                UI_torres.GetComponent<UI_Torres>().guardaInventari(inventari);
                //Menu d'escollir torre
                UI_torres.SetActive(true);
            }

            if (improveGround == true)
            {
                //Millorar Torre
                GameObject g = torreDeCasella(terrenyTorre);
                UI_Upgrade.GetComponent<UI_Upgrade>().OmpleTorreUpgrade(g);
                UI_Upgrade.SetActive(true);
                //Debug.Log("Millorar Torre " + g.name);
                improveGround = false;
                terrenyTorre = null;
            }

            if(improveWay == true)
            {
                GameObject g = torreDeCasella(terrenyTorre);
                UI_Upgrade.GetComponent<UI_Upgrade>().OmpleTorreUpgrade(g);
                UI_Upgrade.SetActive(true);
                Debug.Log("Millorar Torre " + g.name);
                improveWay = false;
                terrenyTorre = null;
            }

        }


        if (Input.GetKeyUp(KeyCode.G))
        {

            Vector3 position = transform.position;

            position.y = 0;
            GameObject bridge = buscaBridge(position);

            //Millorar el pont X
            Debug.Log("Millorem el pont " + bridge.name);
            UI_RepareBridge.GetComponent<UI_RepareBridge>().OmpleBridge(bridge);
            UI_RepareBridge.SetActive(true);


        }


    }

    public GameObject buscaBridge(Vector3 position)
    {
        GameObject[] ponts;
        GameObject bridge = null;

        if (GameObject.FindGameObjectsWithTag("Bridge") != null)
        {
            ponts = GameObject.FindGameObjectsWithTag("Bridge");
        } else
        {
            ponts = null;
        }
            

        float minDist = Mathf.Infinity;

        //Debug.Log("Terreny Length" + terreny.Length);
        for (int i = 0; i < ponts.Length; i++)
        {
            float dist = Vector3.Distance(ponts[i].transform.position, position);
            if (dist < minDist)
            {
                    bridge = ponts[i];
                    minDist = dist;
             }

        }
        //Debug.Log("Caslla final " + terrenyFinal.name);
        return bridge;
    }

    public GameObject buscarWay(Vector3 position)
    {

        GameObject[] terreny;
        GameObject terrenyFinal = null;

        terreny = GameObject.FindGameObjectsWithTag("Way");
        float minDist = Mathf.Infinity;

        //Debug.Log("Terreny Length" + terreny.Length);
        for (int i = 0; i < terreny.Length; i++)
        {
            float dist = Vector3.Distance(terreny[i].transform.position, position);
            if (dist < minDist)
            {
                if (hihaTorre(terreny[i]))
                {
                    terrenyFinal = terreny[i];
                    minDist = dist;
                }
                else
                {
                    terrenyTorre = terreny[i];
                    improveWay = true;
                    return terrenyTorre;
                }
            }

        }
        //Debug.Log("Caslla final " + terrenyFinal.name);
        return terrenyFinal;
    }

    public GameObject buscarCasella(Vector3 position)
    {

        GameObject[] terreny;
        GameObject terrenyFinal = null;

        terreny = GameObject.FindGameObjectsWithTag("Ground");
        float minDist = Mathf.Infinity;

        //Debug.Log("Terreny Length" + terreny.Length);
        for (int i = 0; i < terreny.Length; i++)
        {
            float dist = Vector3.Distance(terreny[i].transform.position, position);
            if (dist < minDist)
            {
                if (hihaTorre(terreny[i]))
                {
                    terrenyFinal = terreny[i];
                    minDist = dist;
                } else
                {
                    terrenyTorre = terreny[i];
                    improveGround = true;
                    return terrenyTorre;
                }
            }

        }
        //Debug.Log("Caslla final " + terrenyFinal.name);
        return terrenyFinal;
    }

    public bool hihaTorre(GameObject g)
    {

        LayerMask mask = LayerMask.GetMask("Torre");

        Vector3 aux = g.transform.position;
        aux.y = -2f;
        if (Physics.Raycast(aux, -g.transform.forward * 10f,  Mathf.Infinity, mask))
        {
            //Debug.DrawRay(aux, -g.transform.forward * 10f, Color.blue, 10f);
            //Debug.Log("Ha Xocat contra una torre");
            return false;
        }
        else
        {
           // Debug.DrawRay(aux, -g.transform.forward * 10f, Color.red, 10f);
           // Debug.Log("No ha xocat contra res");
            return true;
        }
       

    }

    public GameObject torreDeCasella(GameObject casella)
    {
        GameObject torre = null;
        LayerMask mask = LayerMask.GetMask("Torre");

        Vector3 aux = casella.transform.position;
        aux.y = -2f;
        RaycastHit hit;
        if (Physics.Raycast(aux, -casella.transform.forward * 10f, out hit, Mathf.Infinity, mask))
        {
            return hit.collider.gameObject;
        }

        return torre;
            
    }
}

   



