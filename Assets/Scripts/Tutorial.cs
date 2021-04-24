using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public bool tutorial;
    int dia = 0;
    bool eliminaText = false;

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
    // Start is called before the first frame update
    void Start()
    {
        llargadaText = textos.Count;
        tutorial = true;
        count = 0;
        text = textos[count];
        StartCoroutine(mostraText());
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial == true)
        {
            //Debug.Log("Tutorial en proces");

            //Text de benvinguda a la bruixa
            if (eliminaText)
            {
                //Si puc posem una fletxita i l'animem amb l'escala
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    textUI.gameObject.GetComponent<Text>().text = "";
                    count++;
                    text = textos[count];
                    eliminaText = false;
                    StartCoroutine(mostraText());
                }


            }

            Debug.Log("Opcio: " + count);
            switch (count)
            { 
                case 1:
                    //Aqui hem de fer visible el primer cercle
                    cercleVidaTorre.gameObject.SetActive(true);
                    break;
                case 2:
                    //Aqui hem de fer animacio zones
                    waterZone.gameObject.SetActive(true);
                    fireZone.gameObject.SetActive(true);
                    airZone.gameObject.SetActive(true);
                    earthZone.gameObject.SetActive(true);

                    cercleVidaTorre.gameObject.SetActive(false);
                    break;

                case 3:
                    //Aqui ensenyem els recursos
                    cercleRecursosAconseguits.gameObject.SetActive(true);

                    waterZone.gameObject.SetActive(false);
                    fireZone.gameObject.SetActive(false);
                    airZone.gameObject.SetActive(false);
                    earthZone.gameObject.SetActive(false);
                    break;
                case 4:
                    //Aqui posem 3 recursos d'aigua 
                    // Careful q entra en bucle i es torna loco
                    Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, new Vector3(0,4,5), Quaternion.identity);
                    Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, new Vector3(1,4,5), Quaternion.identity);
                    Instantiate(this.gameObject.GetComponent<SpawnResources>().resource[3].prefab, new Vector3(2,3,5), Quaternion.identity);

                    break;

                default:
                    cercleVidaTorre.gameObject.SetActive(false);
                    cercleTempsDia.gameObject.SetActive(false);
                    cercleRecursosAconseguits.gameObject.SetActive(false);

                    waterZone.gameObject.SetActive(false);
                    fireZone.gameObject.SetActive(false);
                    airZone.gameObject.SetActive(false);
                    earthZone.gameObject.SetActive(false);
                    break;
            }
            //Hem de fer el tutorial del joc, quan arribi a l'ultim pas farem false
            //Ensenyem la torre
            //Recursos i ensenyem com pujen
            //Que amb la F posen torretes
            //Que amb la G arreglen ponts
            //Que poden disparar
            //Ensenyem que els enemics peguen a la torre
        }
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
