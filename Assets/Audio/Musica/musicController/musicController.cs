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

    [Range(0f, 1f)]
    public float musicVolume; //Valor de 0 a 1 que es canvia al menu d'opcions per triar el volum de la musica

    void Start()
    { //Inicialitzem la musica de dia i la de nit, pero sol escoltem la de dia
        dia.Play();
        dia.volume = musicVolume;
        nit.Play();
        musicChanging = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { ///////////////////////////////IF PER FER PROBES //////////////////////////////
            changeMusic(); //Crida de la funcio pel canvi de 
        }


        if (musicChanging) { //Ajustem el volum de la musica durant les transicions, per ferles continues
            dia.volume = volumeDay * musicVolume;
            nit.volume = volumeNight * musicVolume;
        }
    }

    public void changeMusic() { //Funcio per canviar de musica
        Debug.Log("CANVIANT MUSICA");
        anim.SetTrigger("ChangeState"); //Trigger per activar transicio
        musicChanging = true; //Avisa que esta en un estat de transicio
    }

    public void musicStopChanging() //Trigger al final de les animacions per avisar del fi de la transicio
    {
        musicChanging = false;
    }


}
