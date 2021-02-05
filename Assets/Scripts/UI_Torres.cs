using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Torres : MonoBehaviour
{

    public List<Torre> torres;
    public List<Bales> bales;
    public List<GameObject> buttons;


    public GameObject casella;
    public Inventory inventari;
    public UI_Inventory inventory;
    public Cursor cursor;

    

    private void Update()
    {
        if(this.enabled)
        {
            cursor.top = true;
            
            UnityEngine.Cursor.visible = true;

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            cursor.top = false;
            UnityEngine.Cursor.visible = false;
        }
        
    }
    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_Inventory>().GetInventory();
    }
 

    public void guardaPosition(GameObject c)
    {
        //Debug.Log("Guarda posicio");
        casella = c;
    }

    public void OnClikButtonTorre(GameObject gameObject)
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < buttons.Count; i++)
        {
            //Debug.Log("Nom1: " + buttons[i].name + " /  Nom2: " + gameObject.name);
            if(buttons[i].name == gameObject.name)
            {
                //Debug.Log(torres[i].name);
                Vector3 position = casella.gameObject.transform.position;
                
                if (torres[i].name == "Torre 4")
                {
                    position.y = 0.395f;
                }
                else
                {
                    position.y = 0.7345991f;
                }
                //Hem de restar els recurosos, i en cas que no tingui els suficients no posar la torreta
                //La torreta ha de tenir els Items q gasta
                bool error = inventari.spendResources(torres[i].element1, torres[i].quantiatElement1, torres[i].element2, torres[i].quantitatElement2);

                if (error == false)
                {
                   // Debug.Log("Hi ha hagut un error");
                } else
                {
                    //Debug.Log("Posem la torre");
                    inventory.RefreshInventoryItems();
                    GameObject go = Instantiate(torres[i].prefab, position, Quaternion.identity);

                    //Aqui posem el q necesitem
                    //go.GetComponent<Turret>().balaPrefab = torres[i].bala;
                    go.GetComponent<Turret>().range = torres[i].range;
                    go.GetComponent<Turret>().fireRate = torres[i].fireRate;
                    go.GetComponent<Turret>().velRotacio = torres[i].velRotacio;
                    go.GetComponent<Turret>().idBala = torres[i].idBala; 
                    go.GetComponent<Turret>().bales = bales;


                    
                }
                cursor.top = false;
                UnityEngine.Cursor.visible = false;
                break;

            }
        }
    }

}
