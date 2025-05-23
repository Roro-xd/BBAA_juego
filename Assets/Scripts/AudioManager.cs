using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{


    //Para incluir los sonidos
    public Sonido[] musica;
    public Sonido[] sfx;
    public Sonido[] voces;
    public AudioSource musicaSource, sfxSource, vocesSource;

    public static AudioManager Instance;



    void Start()
    {
        StartCoroutine("musicaInicio");
    }

    void Update()
    {
        //Para que no se solapen reproducciones con cosas que suceden en Start()
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }


    public void PlayMusica(string nombreSonido)
    {
        Sonido s = Array.Find(musica, x => x.nombreSonido == nombreSonido);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicaSource.clip = s.clip;
            musicaSource.Play();
        }
    }


    public void PlaySFX(string nombreSonido)
    {
        Sonido s = Array.Find(sfx, x => x.nombreSonido == nombreSonido);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }


    public void PlayVoces(string nombreSonido)
    {
        Sonido s = Array.Find(voces, x => x.nombreSonido == nombreSonido);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            vocesSource.Stop();

            vocesSource.PlayOneShot(s.clip);
            vocesSource.Play();
        }
    }


    public void VolMusica(float volumen)
    {
        musicaSource.volume = volumen;
    }

    public void VolSFX(float volumen)
    {
        sfxSource.volume = volumen;
    }

    public void VolVoces(float volumen)
    {
        vocesSource.volume = volumen;
    }

    IEnumerator musicaInicio()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.Instance.PlayMusica("Lobby");

    }
    
}
