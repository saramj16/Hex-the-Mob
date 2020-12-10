using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nou Enemic", menuName = "Enemic")]
public class Enemic : ScriptableObject
{
    public string tipus;

    public float velocitat;
    public int vida;
    public int atac;

    public int dificultat;

    public GameObject prefab;
}
