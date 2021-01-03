using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Torre", menuName ="Torre")] 
public class Torre : ScriptableObject
{
    public string tipus;
    public float danyAtac;

    public int tempsAtac;
    public int vidaTorre;

    public GameObject prefab;
    public GameObject bala;

    public Item.Element element1;
    public int quantiatElement1;

    public Item.Element element2;
    public int quantitatElement2;
    
    

}
