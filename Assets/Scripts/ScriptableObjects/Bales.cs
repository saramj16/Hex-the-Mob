using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Bala", menuName ="Bala")] 
public class Bales : ScriptableObject
{
    [Header("Configuració")]
    public int id;
    public int damage;
    public float velocitatBala = 70f;

    [Header("Impacte")]
    public GameObject efecteImpacte;

    [Header("Prefabs")]
    public GameObject balaPrefab;




    //Falta posar els efectes
}
