using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Enemic> enemic;


    public List<Enemic> ListEnemyWave(int wave)
    {
        int dificultat = dificultatRonda(wave);

        List<Enemic> llistaEnemicsRonda = new List<Enemic>();

        //Debug.LogError("Deixa buit el llistat " + llistaEnemicsRonda.Count);
        // Crear un gestor de waves q en funció de la wave q sigui esculli una dificultat
        while (dificultat != 0)
        {
            int index = Random.Range(0, enemic.Count);
            
            if (dificultat - enemic[index].dificultat < 0)
            {
                int x = dificultat - enemic[index].dificultat;
                //Debug.Log("dificultat menor de 0" + x.ToString());
                break;
            } else
            {
                llistaEnemicsRonda.Add(enemic[index]);
                dificultat = dificultat - enemic[index].dificultat;
                //Debug.Log("dificultat " + dificultat);
            }
        }
        return llistaEnemicsRonda;
    }

    public int dificultatRonda(int wave)
    {
        int dificultat;

        dificultat = wave * 3;

        return dificultat;
    }
}
