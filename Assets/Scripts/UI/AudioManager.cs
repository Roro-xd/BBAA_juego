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
    public Sonido[] otros;
    public AudioSource musicaSource, sfxSource, vocesSource, otrosSource;

    public static AudioManager Instance;



    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene escena, LoadSceneMode modoEscena) {

        if (escena.name == "Inicio" || escena.name == "Victoria")
        {
            otrosSource.Stop();
            PlayMusica("Intro");
        }
        else if (escena.name == "InicioLobby")
        {
            sfxSource.Stop();
            sfxSource.Play();
            otrosSource.Play();
            PlayMusica("Lobby");
            PlayOtros("VocesFondo");
        }
        //EN ESTA ESCENA NO PUEDEN SONAR LAS VOCES PORQUE YA ESTÁ SONANDO EL CAMINADO DEL PERSONAJE DESDE EL MISMO AUDIOSOURCE
        //Ya es tarde para cambiarlo todo
        else if (escena.name == "LobbyInteractuable")
        {
            if (!musicaSource.isPlaying)
            {
                PlayMusica("Lobby");
            }

            /*if (!otrosSource.isPlaying) {
                PlayOtros("vocesFondo");
            }*/
        }
        else if (escena.name == "Level_1")
        {
            otrosSource.Stop();
            PlayMusica("Piso");
        }
        else if (escena.name == "BOSS")
        {
            otrosSource.Stop();
            PlayMusica("MiniBoss");
        }
        else if (escena.name == "Derrota")
        {
            otrosSource.Stop();
            PlayMusica("Derrota");
        }
        else if (escena.name == "EnAscensor")
        {
            otrosSource.Stop();
            PlayMusica("LobbyLejos");
        }
        else
        {
            musicaSource.Stop();
        }
    }


    void Start()
    {

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
            musicaSource.Stop();

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

    public void PlayOtros(string nombreSonido)
    {
        Sonido s = Array.Find(otros, x => x.nombreSonido == nombreSonido);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            otrosSource.Stop();
            otrosSource.clip = s.clip;
            otrosSource.Play();
        }
    }


    public void VolMusica(float volumen)
    {
        musicaSource.volume = volumen;
    }

    public void VolSFX(float volumen) ////+Otros
    {
        sfxSource.volume = volumen;
        otrosSource.volume = volumen;
    }

    public void VolVoces(float volumen)
    {
        vocesSource.volume = volumen;
    }

    
}
