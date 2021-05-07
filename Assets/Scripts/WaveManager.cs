﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Light sol;
    public Color32 dia, nit, ColorSol;
    public musicController musicController;
    public bool esDia = true;

    public float tempsDia = 10f;
    public int nDia = 0;
    public int nNit = 0;
    public float LightTransitionDiaTime = 1f; // duration in seconds
    //public Transform enemyPrefab;
    public Transform spawnPoint;

    public List<Enemic> enemic = new List<Enemic>();

    public EnemyWaves enemyWaves;

    public bool HiHaEnemics;
    public float countdown;

    private int waveNumber = 0;

    private void Start()
    {
        Debug.Log("Fa l'Start");
        musicController = musicController.GetComponent<musicController>();
        sol = GameObject.Find("Sol").GetComponent<Light>();
        HiHaEnemics = false;
        

        //Hexa: FFF4D6
        dia = new Color32(255, 244, 214, 255);
        ColorSol = dia;
        //Hexa: A4A3FF
        nit = new Color32(163, 162, 255, 255);
        countdown = tempsDia;

        sol.color = ColorSol;
        //Comprovar si hi ha enemics començant al segon 1, cada 1 segons
        InvokeRepeating("CheckForEnemies", 1f, 1f);

        
    }

    private void Update()
    {
        //Debug.Log("Tutorial: " + this.gameObject.GetComponent<Tutorial>().tutorial);
        if(this.gameObject.GetComponent<Tutorial>().tutorial == false)
        {
            if (countdown <= 0 && esDia)
            {
                StartCoroutine(SpawnWave());
                SetNit();

            }
            if (!HiHaEnemics && !esDia)
            {
                SetDia();
            }

            sol.color = ColorSol;
            countdown -= Time.deltaTime;
            LightTransitionDiaTime -= Time.deltaTime;
        } else
        {
            esDia = true;
            sol.color = ColorSol;
        }
    }

    public IEnumerator SpawnWave()
    {
        waveNumber++;

        GetWaveList(waveNumber);
      //  Debug.Log("Wave Incoming!");
        StartCoroutine(SpawnEnemy());
        yield return new WaitForSeconds(0.5f);
        /*for (int i = 0; i < waveNumber; i++)
        {
            
            yield return new WaitForSeconds(0.5f);
        }*/

        StopCoroutine(SpawnEnemy());
       // Debug.Log("Tanquem la corrutina");
    }

    void GetWaveList(int waveNumber)
    {
        enemic.Clear();
        //Debug.Log("No hi ha enemics a la llista: " + enemic.Count);
        enemic = enemyWaves.ListEnemyWave(waveNumber);
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemic.Count; i++)
        {
        //    Debug.Log("Nom enemic: " + enemic[i].prefab.name);
            //Fer-ho cada X temps
            Instantiate(enemic[i].prefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }
    public void SetNit()
    {
        musicController.changeMusic();
        LightTransitionDiaTime = 1f;
        esDia = false;
        nNit++;
        //sol.color = nit;
        HiHaEnemics = true;
        //Debug.Log("Nit num: " + nNit);
        ColorSol = Color.Lerp(dia, nit, LightTransitionDiaTime);

        // Busquem recursos i els eliminem
        GameObject[] recursos = GameObject.FindGameObjectsWithTag("Resource");
        for(int i = 0; i < recursos.Length; i++)
        {
            Destroy(recursos[i]);
        }
    }

   public  void SetDia()
    {
        musicController.changeMusic();
        LightTransitionDiaTime = 1f;
        nDia++;
        //Debug.Log("Dia num: " + (nDia));
        countdown = tempsDia;
        esDia = true;
        ColorSol = Color.Lerp(nit, dia, LightTransitionDiaTime);
    }

    void CheckForEnemies()
    {
        //Debug.Log("Buscant enemics...");
        if (!esDia && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            HiHaEnemics = false;
        }
    }
}
