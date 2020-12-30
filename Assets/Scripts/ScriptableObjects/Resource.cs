using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName ="Recurs")] 
public class Resource : ScriptableObject
{
    public GameObject prefab;
    public bool picked;
    public int type;
}
