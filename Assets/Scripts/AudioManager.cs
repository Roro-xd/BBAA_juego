using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

public AudioSource audioSource;
//Para incluir la banda sonora
public AudioClip lobby;
public AudioClip piso;
public AudioClip miniBosses;
public AudioClip bossFinal;

//Para incluir los SFX
public AudioClip botones;
public AudioClip menuYflechas;



    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = lobby;
        audioSource.Play();
        
    }

    void Update()
    {
        
    }
}
