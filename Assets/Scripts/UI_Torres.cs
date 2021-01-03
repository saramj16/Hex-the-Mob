using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Torres : MonoBehaviour
{

    public List<Torre> torres;
    public List<GameObject> buttons;

    public GameObject casella;
    public Inventory inventari;
    public UI_Inventory inventory;

    public void guardaInventari(GameObject i)
    {
        inventari = i.GetComponent<UI_Inventory>().GetInventory();
    }
 

    public void guardaPosition(GameObject c)
    {
        Debug.Log("Guarda posicio");
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
                Debug.Log("Entra a posar la torre");
                Vector3 position = casella.gameObject.transform.position;
                position.y = 0.7345991f;
                

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
                    Instantiate(torres[i].prefab, position, Quaternion.identity);
                }
                break;

            }
        }
    }

}
