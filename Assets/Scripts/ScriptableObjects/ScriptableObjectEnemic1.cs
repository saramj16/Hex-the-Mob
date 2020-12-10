using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectEnemic1 : MonoBehaviour
{
    public float velocitat;
    public int vida;
    public int atac;

    public GameObject prefab;

    public Enemic enemic;

    // Update is called once per frame
    void Update()
    {
        UpdateEnemicValues();
    }

    public void SetSoValues(Enemic e)
    {
        enemic = e;
    }

    private void UpdateEnemicValues()
    {
        if (velocitat != enemic.velocitat)
        {
            velocitat = enemic.velocitat;
        }

        if (atac != enemic.atac)
        {
            atac = enemic.atac;
        }

        if (vida != enemic.vida)
        {
            vida = enemic.vida;
        }

        if (prefab != enemic.prefab)
        {
            prefab = enemic.prefab;
        }
    }
}
