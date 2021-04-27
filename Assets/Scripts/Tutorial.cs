using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject bruixa;
    
    public Inventory inventory;

    public GameObject waypointEnemicTutorial;
    public GameObject enemic;

    public bool tutorial = false;

    bool eliminaText = false;

    // Variables per marcar que només es facin les coses un cop
    bool accioAcabada = false;
    bool accioInici = false;
    

    //Cercles per marcar
    public Image cercleVidaTorre;
    public Image cercleTempsDia;
    public Image cercleRecursosAconseguits;

    //Imatges recursos zones
    public Image waterZone;
    public Image earthZone;
    public Image fireZone;
    public Image airZone;
    //Efectes text
    public float delay = 0.1f;
    public string text;
    private string currentText = "";

    public GameObject textUI;

    public List<string> textos;
    int llargadaText;
    int count;
    int ultimMissatge;

    

    // Start is called before the first frame update
    void Start()
    {
        llargadaText = textos.Count;
        tutorial = true;
        count = 0;
        text = textos[count];
        StartCoroutine(mostraText());
    }


    public void SetInventory(Inventory i)
    {
        inventory = i;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial == true)
        {
            bruixa.GetComponent<PlayerShoot>().potDisparar = false;
            //Debug.Log("Elimina text: " + eliminaText);
            //Debug.Log("Accio acabada: " + eliminaText);

            //Text de benvinguda a la bruixa
            if (eliminaText && accioAcabada)
            {
                //Debug.Log("Pot entrar a lo del click ");

                //Si puc posem una fletxita i l'animem amb l'escala
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    if (count == llargadaText-1)
                    {
                        tutorial = false;
                        accioInici = true;
                        textUI.gameObject.GetComponent<Text>().text = "";
                        Debug.Log("Ha acabat el tutorial");
                    } else
                    {
                        NextPas();
                    }
                    
                }


            }

            //Debug.Log("Opcio: " + count);
            if(!accioInici)
            {
                switch (count)
                {
                    case 1:
                        //Aqui hem de fer visible el primer cercle
                        accioAcabada = true;
                        
                        cercleVidaTorre.gameObject.SetActive(true);


                        break;
                    case 2:
                        accioInici = true;
                        accioAcabada = false;
                        cercleVidaTorre.gameObject.SetActive(false);

                        //Aqui hem de fer animacio zones
                        StartCoroutine(AnimacioZonesRecursos());
                        
                        break;

                    case 3:
                        
                        accioAcabada = true;
                        waterZone.gameObject.SetActive(false);
                        fireZone.gameObject.SetActive(false);
                        airZone.gameObject.SetActive(false);
                        earthZone.gameObject.SetActive(false);

                        //Aqui ensenyem els recursos
                        cercleRecursosAconseguits.gameObject.SetActive(true);
                        
              

                        break;
                    case 4:
                        accioInici = true;
                        accioAcabada = false;
                        cercleRecursosAconseguits.gameObject.SetActive(false);
                        //Aqui posem 3 recursos d'aigua 
                        // Careful q entra en bucle i es torna loco

                        //Han d'estar a prop de la bruixeta
                        this.gameObject.GetComponent<SpawnResources>().ground = this.gameObject.GetComponent<SpawnResources>().water;
                        
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);
                        Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, this.gameObject.GetComponent<SpawnResources>().calculateResourcePosition(), Quaternion.identity);

                        Invoke("HaAgafatRecursos", 1f);
                        break;

                    case 6:
                       // accioInici = true;
                        accioAcabada = true;
                        //Es quan ha d'apretar F i posar la torre, no pot passar d'opcio fins que no hagi consturit una torre
                        Invoke("HaPosatTorre", 1f);
                        break;

                    case 7:
                        accioInici = true;
                        accioAcabada = false;

                        Debug.Log("Entra al CASE 7");
                        //S'ha de fer de nit i sortir una oleada
                        //Instantiate(enemic, waypointEnemicTutorial.transform.position, waypointEnemicTutorial.transform.rotation);
                        //Invoke("HaAcabatLaOleada", 1f);
                        break;
                    default:
                        accioAcabada = true;
                        cercleVidaTorre.gameObject.SetActive(false);
                        cercleTempsDia.gameObject.SetActive(false);
                        cercleRecursosAconseguits.gameObject.SetActive(false);

                        waterZone.gameObject.SetActive(false);
                        fireZone.gameObject.SetActive(false);
                        airZone.gameObject.SetActive(false);
                        earthZone.gameObject.SetActive(false);
                        break;
                }
            }
        } else
        {
            bruixa.GetComponent<PlayerShoot>().potDisparar = true;

            textUI.gameObject.GetComponent<Text>().text = "";
            cercleVidaTorre.gameObject.SetActive(false);
            cercleTempsDia.gameObject.SetActive(false);
            cercleRecursosAconseguits.gameObject.SetActive(false);

            waterZone.gameObject.SetActive(false);
            fireZone.gameObject.SetActive(false);
            airZone.gameObject.SetActive(false);
            earthZone.gameObject.SetActive(false);
        }
    }


    void HaAcabatLaOleada()
    {
        int enemics = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemics == 0)
        {
            accioAcabada = true;

            NextPas();
        }
        else
        {
            Invoke("HaAcabatLaOleada", 1f);
        }
    }
    void NextPas()
    {
        accioInici = false;
        textUI.gameObject.GetComponent<Text>().text = "";
        count++;
        text = textos[count];
        eliminaText = false;
        StartCoroutine(mostraText());
    }

    void HaAgafatRecursos()
    {
        int recursos = 0;

        recursos = inventory.AmountRecurs(Item.Element.Water);
        if(recursos >= 7)
        {
            accioAcabada = true;

            GameObject[] r = GameObject.FindGameObjectsWithTag("Resource");
            for (int i = 0; i < r.Length; i++)
            {
                Destroy(r[i]);
            }
            NextPas();
        } else
        {
            Invoke("HaAgafatRecursos", 1f);
        }
    }

    void HaPosatTorre()
    {
        int torre = 0;

        torre = GameObject.FindGameObjectsWithTag("Torre").Length;
        if (torre >= 1)
        {
            accioAcabada = true;
            NextPas();
        }
        else
        {
            Invoke("HaPosatTorre", 1f);
        }
    }


    IEnumerator AnimacioZonesRecursos()
    {
        waterZone.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        earthZone.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        airZone.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        fireZone.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        accioAcabada = true;
        
        //Debug.Log("Acaben animacions");
   
    }


    IEnumerator mostraText()
    {
        for (int i = 0; i < text.Length + 1; i++)
        {
            currentText = text.Substring(0, i);
            textUI.gameObject.GetComponent<Text>().text = currentText;

            if (i == text.Length - 1)
            {
                //Debug.Log("Entra a destruir el missatge");
                eliminaText = true;

                
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }

        }
    }
}
