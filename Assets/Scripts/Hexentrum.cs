using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hexentrum : MonoBehaviour
{
    public float vidaActual = 10000f;
    public float vidaMaxima = 10000f;

    public void restaVida(float dany)
    {
        vidaActual -= dany;
        //Debug.Log("Vida  " +vida);
        if (vidaActual <= 0)
        {
            //Debug.LogError("Game OVER");
            SceneManager.LoadScene("GameOver");
        }
    }
}
