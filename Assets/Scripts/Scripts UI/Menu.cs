using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;
    public GameObject credits;
    public GameObject selectMap;

    public Slider sliderMusic;
    public Slider sliderEffects;
    // Start is called before the first frame update
    public void OnClickPlay()
    {
        menu.gameObject.SetActive(false);
        selectMap.gameObject.SetActive(true);

    }

    public void OnClickOptions()
    {
        menu.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
    }

    public void OnClickCredits()
    {
        menu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void GoBack()
    {
        menu.gameObject.SetActive(true);
        selectMap.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    public void ModifcarAudioMusic()
    {
       // Debug.Log("Volum musica a: " + sliderMusic.value);
       float volum = sliderMusic.value;
    }


    public void ModifcarAudioEffects()
    {
       // Debug.Log("Volum efectes a: " + sliderEffects.value);
        float volum = sliderEffects.value;
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void Mapa1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Mapa2()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    public void Mapa3()
    {
        //SceneManager.LoadScene("SampleScene");
    }
}
