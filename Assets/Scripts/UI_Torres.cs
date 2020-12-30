using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Torres : MonoBehaviour
{

    public List<Torre> torres;
    public List<GameObject> buttons;

    public GameObject casella;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guardaPosition(GameObject c)
    {
        casella = c;
    }

    public void OnClikButtonTorre(GameObject gameObject)
    {
        this.gameObject.SetActive(false);
        for (int i = 0; i < buttons.Count; i++)
        {
            Debug.Log("Nom1: " + buttons[i].name + " /  Nom2: " + gameObject.name);
            if(buttons[i].name == gameObject.name)
            {
                Debug.Log("Entra a posar la torre");
              
                Vector3 position = casella.gameObject.transform.position;
                position.y = 0.7345991f;
                Instantiate(torres[i].prefab, position, Quaternion.identity);

                //Hem de restar els recurosos, i en cas que no tingui els suficients no posar la torreta
            }
        }
    }

}
