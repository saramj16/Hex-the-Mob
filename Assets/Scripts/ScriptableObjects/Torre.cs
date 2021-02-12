using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Torre", menuName ="Torre")] 
public class Torre : ScriptableObject
{
    public Bales bala;
    //public int vidaTorre;
    [Range(0,10)]
    public float range;
    
    public float fireRate;
    public float velRotacio;

    [Header("Prefabs")]
    public GameObject prefab;

    
    [Header("Recursos")]
    public Item.Element element1;
    public int quantiatElement1;
 
    public Item.Element element2;
    public int quantitatElement2;
    
    

}
