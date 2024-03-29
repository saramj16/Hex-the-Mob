﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UI_Torres : MonoBehaviour
{

    public List<Torre> torres;
    public List<GameObject> buttons;

    public GameObject casella;
    public GameObject cami;
    public Inventory inventari;
   // public UI_Inventory inventory;
    public UI_InGame inventory;
    public GameObject cursor;

    public GameObject earth;
    public GameObject water;
    public GameObject air;
    public GameObject fire;

    public Sprite imatgeEarth;
    public Sprite imatgeWater;
    public Sprite imatgeAir;
    public Sprite imatgeFire;
    public Sprite imatgeNull;

    public GameObject quantitatElements;
    public GameObject personatge;

    public GameObject camera; 


    public void OmplePersonatge(GameObject g)
    {
        personatge = g;

    }
    public void Start()
    {
    
        GameObject panel;
        int j = 0;
        while(j < torres.Count) { 
            panel = null;
            if(j >= 0 && j < 3)
            {
    
                panel = earth;
            }
            if (j >= 3 && j < 6)
            {
                //Debug.Log("Entra a la Water");
                panel = water;
            }
            if (j >= 6 && j < 9)
            {
                //Debug.Log("Entra a la Air");
                panel = air;
            }
            if (j >= 9 && j < 12)
            {
                //Debug.Log("Entra a la Fire");
                panel = fire;
            }

            for (int i = 0; i < 3; i++)
            {
                GameObject panelAux;
                panelAux = panel.gameObject.transform.GetChild(i).gameObject;
                //Debug.Log("Panel " + panel.name);
                panelAux.transform.GetChild(0).GetComponent<Text>().text = torres[j].nom;
                panelAux.transform.GetChild(1).GetComponent<Text>().text = torres[j].description;

                panelAux.transform.GetChild(2).GetComponent<Image>().sprite = retornaElement(torres[j].element1);
                if(torres[j].quantitatElement2 == 0)
                {
                    panelAux.transform.GetChild(3).GetComponent<Image>().sprite = null;
                } else {
                
                    panelAux.transform.GetChild(3).GetComponent<Image>().sprite = retornaElement(torres[j].element2);
                            
                }

                panelAux.transform.GetChild(4).GetComponent<Image>().sprite = torres[j].imatge;

                panelAux.transform.GetChild(5).GetComponent<Text>().text = torres[j].quantiatElement1.ToString();
                if(torres[j].quantitatElement2 == 0)
                {
                    panelAux.transform.GetChild(6).GetComponent<Text>().text = " ";
                } else
                {
                    panelAux.transform.GetChild(6).GetComponent<Text>().text = torres[j].quantitatElement2.ToString();
                }
                
                j++;
            }
        }

        quantitatElements.transform.GetChild(0).GetComponent<Text>().text = inventari.items[0].amount.ToString();
        quantitatElements.transform.GetChild(1).GetComponent<Text>().text = inventari.items[1].amount.ToString();
        quantitatElements.transform.GetChild(2).GetComponent<Text>().text = inventari.items[2].amount.ToString();
        quantitatElements.transform.GetChild(3).GetComponent<Text>().text = inventari.items[3].amount.ToString();

    }

    public void SetInventory(Inventory i)
    {
        inventari = i;
    }
    private Sprite retornaElement(Item.Element e)
    {
        switch (e)
        {
            case Item.Element.Water:
                return imatgeWater;
            case Item.Element.Air:
                return imatgeAir;
            case Item.Element.Fire:
                return imatgeFire;
            case Item.Element.Earth:
                return imatgeEarth;
            default:
                return null;
        }
        

    }
    private void Update()
    {
        if(this.enabled)
        {
            quantitatElements.transform.GetChild(0).GetComponent<Text>().text = inventari.items[0].amount.ToString();
            quantitatElements.transform.GetChild(1).GetComponent<Text>().text = inventari.items[1].amount.ToString();
            quantitatElements.transform.GetChild(2).GetComponent<Text>().text = inventari.items[2].amount.ToString();
            quantitatElements.transform.GetChild(3).GetComponent<Text>().text = inventari.items[3].amount.ToString();
            //cursor.top = true;
            cursor.SetActive(false);
            UnityEngine.Cursor.visible = true;

            //Aqui hem de fer PAUSE a la CAMERA
            camera.gameObject.GetComponent<CinemachineBrain>().enabled = false;
            inventory.gameObject.SetActive(false);

        }        
    }
    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_InGame>().GetInventory();
    }
 

    public void guardaPosition(GameObject c, GameObject way)
    {
        //Debug.Log("Guarda posicio");
        casella = c;
        cami = way;
    }
    public void OnClickButtonClose()
    {
        Debug.Log("Tanca");
        inventory.gameObject.SetActive(true);
        cursor.SetActive(true);
        UnityEngine.Cursor.visible = false;
        camera.gameObject.GetComponent<CinemachineBrain>().enabled = true;
        personatge.GetComponent<PlayerShoot>().ActivaCursor();
        this.gameObject.SetActive(false);
    }

    public float positionYMesh(GameObject g)
    {
        float altura = 0;

        LayerMask mask = LayerMask.GetMask("Terra");

        RaycastHit hit;
        Vector3 aux = g.transform.position;
        aux.y = 300f;
        if (Physics.Raycast(aux, -g.transform.forward * 1000f, out hit, Mathf.Infinity, mask))
        {
            
            //Debug.DrawRay(aux, -g.transform.forward * 1000f, Color.blue, 10f);
            
            altura = hit.point.y;
            Debug.Log("Altura: " + altura);
        }

            return altura;
    }


    public void OnClikButtonTorre(GameObject gameObject)
    {
        //Debug.Log("Li fa click al button");
        this.gameObject.SetActive(false);
        inventory.gameObject.SetActive(true);
        for (int i = 0; i < buttons.Count; i++)
        {
            //Debug.Log("Nom1: " + buttons[i].name + " /  Nom2: " + gameObject.name);
            if(buttons[i].name == gameObject.name)
            {
                Vector3 position = new Vector3();
                //Debug.Log(torres[i].name);
                if (torres[i].inGround)
                {
                    position = casella.gameObject.transform.position;
                }

                if (torres[i].inWay)
                {
                    position = cami.gameObject.transform.position;
                }

               if (torres[i].inGround)
                {
                    position.y = positionYMesh(casella);
                    //position.y = 0.4f;
                }
                if (torres[i].inWay)
                {
                    position.y = positionYMesh(cami);
                    //position.y = 0.23f;
                }
  
                //Hem de restar els recurosos, i en cas que no tingui els suficients no posar la torreta
                //La torreta ha de tenir els Items q gasta
                bool error = inventari.spendResources(torres[i].element1, torres[i].quantiatElement1, torres[i].element2, torres[i].quantitatElement2);

                if (error == true)
                {
                   //Debug.Log("Hi ha hagut un error");
                    //Debug.Log("Posem la torre");
                    inventory.RefreshInventoryItems();
                    
                    GameObject go = Instantiate(torres[i].prefab, position, Quaternion.identity);

                    Turret t = go.AddComponent<Turret>();
                    t = go.GetComponent<Turret>();
                   
                    t.nomTorre = torres[i].nom;
                    t.range = torres[i].range;
                    t.minRange = torres[i].minRange;
                    t.areaDamage = torres[i].areaDamage;
                    t.fireRate = torres[i].fireRate;
                    t.velRotacio = torres[i].velRotacio;
                    t.bala = torres[i].bala;
                    t.level = torres[i].level;
                    
                }
                //Debug.Log("Arriba aqui");
                cursor.SetActive(true);
                UnityEngine.Cursor.visible = false;
                camera.gameObject.GetComponent<CinemachineBrain>().enabled = true;
                personatge.GetComponent<PlayerShoot>().ActivaCursor();
                break;

            }
        }
    }

}
