using System.Collections;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public AudioSource dia; //Musica de dia
    public AudioSource nit; //Musica de nit
    public Animator anim;   //Animador que controla les transicions entre musica de dia i nit
    private bool musicChanging; //Bool que avisa si la musica està canviant
    public float volumeDay;
    public float volumeNight;

    private string musicVolumePrefsName;
    private string effectsVolumePrefsName;

    [Range(0f, 1f)]
    public float musicVolume; //Valor de 0 a 1 que es canvia al menu d'opcions per triar el volum de la musica
    public float effectVolume; //Valor de 0 a 1 que es canvia al menu d'opcions per triar el volum de la musica


    private void Awake()
    {
        
        musicVolume = PlayerPrefs.GetFloat("volumMusica", 1);
 //       Debug.Log("Volum Musica: " + musicVolume);

        effectVolume = PlayerPrefs.GetFloat("volumEfectes", 1);
        GameObject[] bales = GameObject.FindGameObjectsWithTag("Bullet");

    //    Debug.Log("Volum effectes: " + effectVolume);
        for (int i = 0; i < bales.Length; i++)
        {
            bales[i].GetComponent<AudioSource>().volume = effectVolume;
        }
    }

    void Start()
    { //Inicialitzem la musica de dia i la de nit, pero sol escoltem la de dia
        dia.Play();
        dia.volume = musicVolume;
        nit.Play();
        musicChanging = false;
        
    }

    void Update()
    {
  

        if (musicChanging) { //Ajustem el volum de la musica durant les transicions, per ferles continues
            dia.volume = volumeDay * musicVolume;
            nit.volume = volumeNight * musicVolume;
        }
    }

    public void changeMusic() { //Funcio per canviar de musica
        //Debug.Log("CANVIANT MUSICA");
        anim.SetTrigger("ChangeState"); //Trigger per activar transicio
        musicChanging = true; //Avisa que esta en un estat de transicio
    }

    public void musicStopChanging() //Trigger al final de les animacions per avisar del fi de la transicio
    {
        musicChanging = false;
    }


}
