using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public Light sol;
    public bool HiHaEnemics;
    public Color32 dia, nit, ColorSol;

    public bool esDia = true;

    public float tempsDia = 5f;
    public int nDia = 0;
    public int nNit = 0;
    public float LightTransitionDiaTime = 1f; // duration in seconds
    private float countdown = 2f;

    private void Start()
    {
     
        sol = GameObject.Find("Sol").GetComponent<Light>();
        HiHaEnemics = GameObject.Find("GameMaster").GetComponent<WaveSpawner>().HiHaEnemics;
        sol.color = ColorSol;
        //Hexa: FFF4D6
        dia = new Color32(255, 244, 214, 255);
        ColorSol = dia;
        //Hexa: A4A3FF
        nit = new Color32(163, 162, 255, 255);

        //Debug.Log("Dia num: 1");
    }
    private void Update()
    {
        if (countdown <= 0)
        {
            if (esDia)
            {
                SetNit();
            } else
            {
                if(HiHaEnemics == false)
                {
                    SetDia();
                }
            }
        }

        if (esDia)
        {
            ColorSol = Color.Lerp(dia, nit, LightTransitionDiaTime);
        }
        else
        {
            ColorSol = Color.Lerp(nit, dia, LightTransitionDiaTime);
        }

        sol.color = ColorSol;
        countdown -= Time.deltaTime;
        LightTransitionDiaTime -= Time.deltaTime;
    }

    void SetNit()
    {
        LightTransitionDiaTime = 1f;
        esDia = false;
        nNit++;
        //sol.color = nit;
        HiHaEnemics = true;
        //Debug.Log("Nit num: " + nNit);
    }

    void SetDia()
    {
        LightTransitionDiaTime = 1f;
        nDia++;
        //Debug.Log("Dia num: " + (nDia));
        countdown = tempsDia;
        esDia = true;
        //sol.color = dia;
    }

}
