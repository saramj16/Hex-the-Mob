using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hexentrum : MonoBehaviour
{
    private float vida = 10000f;

    public void restaVida(float dany)
    {
        vida -= dany;
        //Debug.Log("Vida  " +vida);
        if (vida <= 0)
        {
            //Debug.LogError("Game OVER");
            SceneManager.LoadScene("GameOver");
        }
    }
}
