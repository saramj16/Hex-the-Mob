using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    //public Transform enemyPrefab;
    public Transform spawnPoint;

    public List<Enemic> enemic = new List<Enemic>();

    public EnemyWaves enemyWaves;

    public bool HiHaEnemics = false;
    public float timeBetweenWaves = 10f;
    private float countdown = 5f;

    private int waveNumber = 0;

    private void Start()
    {
        //Comprovar si hi ha enemics començant al segon 10, cada 5 segons
        InvokeRepeating("CheckForEnemies", 10f, 5f);
    }

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    public IEnumerator SpawnWave()
    {
        waveNumber++;

        GetWaveList(waveNumber);
        //Debug.Log("Wave Incoming!");
        for(int i =0; i<waveNumber; i++)
        {
            StartCoroutine(SpawnEnemy());
            yield return new WaitForSeconds(0.5f);
        }
    }

    void GetWaveList(int waveNumber)
    {
        enemic = enemyWaves.ListEnemyWave(waveNumber);
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemic.Count; i++)
        {
           //Debug.Log("Nom enemic: " + enemic[i].prefab.name);
           //Fer-ho cada X temps
            Instantiate(enemic[i].prefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

    void CheckForEnemies()
    {
        Debug.Log("Buscant enemics...");
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            HiHaEnemics = false;
        }
    }

}
