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
    public GameObject loading;

    public Slider sliderMusic;
    public Slider sliderEffects;

    private string musicVolumePrefsName;
    private string effectsVolumePrefsName;
    // Start is called before the first frame update
    public void OnClickPlay()
    {
        PlayerPrefs.SetInt("tuto", 0);
        Mapa1();
        
        menu.gameObject.SetActive(false);
        loading.SetActive(true);
        //selectMap.gameObject.SetActive(true);

    }

    public void OnClickTutorial()
    {
        PlayerPrefs.SetInt("tuto", 1);
        Mapa1();
        
        menu.gameObject.SetActive(false);
        loading.SetActive(true);
        //selectMap.gameObject.SetActive(true);

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
        Debug.Log("Volum musica a: " + sliderMusic.value);
        float volum1 = sliderMusic.value;
        PlayerPrefs.SetFloat("volumMusica", volum1);
    }


    public void ModifcarAudioEffects()
    {
        Debug.Log("Volum efectes a: " + sliderEffects.value);
        float volum2 = sliderEffects.value;
        PlayerPrefs.SetFloat("volumEfectes", volum2);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void Mapa1()
    {
        PlayerPrefs.SetFloat("volumMusica", sliderMusic.value);
        PlayerPrefs.SetFloat("volumEfectes", sliderEffects.value);
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
