using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nova Bala", menuName ="Bala")] 
public class Bales : ScriptableObject
{
    //Falta posar els efectes
    public float pushForce;
    public float poisonDamage;
    public float posionDuration;
    public float freezeDuration;
    public bool multiBala;
    public float minArea;
    public bool flameThrower; 

    [Header("Configuració")]
    public int damage;
    public float velocitatBala = 70f;

    [Header("Impacte")]
    public GameObject efecteImpacte;

    [Header("Prefabs")]
    public GameObject balaPrefab;




}
