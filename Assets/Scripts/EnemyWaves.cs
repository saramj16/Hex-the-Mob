using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public List<Enemic> enemic;

    List<Enemic> llistaEnemicsRonda;

    void Start()
    {
        llistaEnemicsRonda = new List<Enemic>();
        //llistaEnemicsRonda.Clear();
    }
    public List<Enemic> ListEnemyWave(int wave)
    {
        int dificultat = dificultatRonda(wave);
        Debug.Log("Wave " + wave + " Dificultat: " + dificultat);
        llistaEnemicsRonda.Clear();
        Debug.Log("Llista enemics " + llistaEnemicsRonda.Count);

        //Debug.LogError("Deixa buit el llistat " + llistaEnemicsRonda.Count);
        // Crear un gestor de waves q en funció de la wave q sigui esculli una dificultat
        while (dificultat != 0)
        {
            int index = Random.Range(0, enemic.Count);
            
            if (dificultat - enemic[index].dificultat >= 0)
            {
                Debug.Log("Enemic: " + enemic[index].name + "Dificultat enemic: " + enemic[index].dificultat);
                llistaEnemicsRonda.Add(enemic[index]);
                dificultat = dificultat - enemic[index].dificultat;
                Debug.Log("Dificultat que queda: " + dificultat);

            }
        }

        Debug.Log("Llista enemics a retornar: " + llistaEnemicsRonda.Count);

        return llistaEnemicsRonda;
    }

    public int dificultatRonda(int wave)
    {
        int dificultat;

        dificultat = wave * 3;

        return dificultat;
    }
}
