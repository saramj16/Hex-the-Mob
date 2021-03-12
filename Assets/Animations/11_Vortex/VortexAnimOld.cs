using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexAnimOld : MonoBehaviour
{
    public Animator at;
    public Material m1;
    public Material m2;
    public bool eCh = false;
    public float emissionStrength;

    // Start is called before the first frame update
    void Start()
    {
      //  m = this.GetComponent<GameObject>().material;
        m1 = this.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        m2 = this.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) { //IF per fer probes/////////////////////
            changeState();
        }

       if (eCh) {
            m1.SetFloat("EmissionStrength", emissionStrength);
            m2.SetFloat("EmissionStrength", emissionStrength);
            print("EEEEEEEEEAAAAAAAAAAAAAAAAAAA");
        }

    }

    //Funcio per canviar d'estat l'animacio de la caixa
    public void changeState() {
        at.SetTrigger("changeState"); //Trigger que canvia l'estat de la caixa
        at.SetBool("open", !at.GetBool("open")); //Invertim el seu estat del animator
        if (!at.GetBool("open")) {

        }
    }

    public void beginEmissionChange() {
        eCh = true;
    }

    public void finishEmissionChange() {
        eCh = false;
        print("ACABAT");
    }
}
