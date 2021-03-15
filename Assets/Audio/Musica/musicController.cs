using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public AudioSource dia;
    public AudioSource nit;
    private bool esDia;
    private bool keepFadeOut;

    // Start is called before the first frame update
    void Start()
    { //Inicialitzem la musica de dia
        dia.Play();
        nit.Stop();
        esDia = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { //IF PER FER PROVES //////////////////////////////
            changeMusic();
        }
        
    }

    void changeMusic() { //Funcio per canviar de musica
        if (esDia)
        {
           // FadeOut(dia,2);
            dia.Stop();
            nit.volume = 0.2f;
            nit.Play();
            esDia = false;
        }
        else {
           // FadeOut(nit, 2);
            nit.Stop();
            dia.volume = 1;
            dia.Play();
            esDia = true;
        }
      
    }


    //Vaig intentar fer funcions de Fade per que la transicio entre cançons fos menys brusca, pero no em surt xd
    //Si ho solucioneu guay i sino no probleeem

    public static IEnumerator OldFadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public IEnumerator FadeIn(AudioSource track, float speed, float maxVolume) {
        keepFadeOut = true;
        track.volume = 0;
        float audioVolume = track.volume;

        while (track.volume < maxVolume && keepFadeOut) {
            audioVolume += speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    
    }

    public IEnumerator FadeOut(AudioSource track, float speed)
    {
        keepFadeOut = true;
        float audioVolume = track.volume;

        while (track.volume >= speed && keepFadeOut)
        {
            audioVolume -= speed;
            track.volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }

        track.Stop();

    }
}
