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
public AudioClip churroHabla;
public AudioClip bunueloHabla;
public AudioClip napoHabla;
public AudioClip yoriqHabla;
public AudioClip atacando;
public AudioClip atacan;
public AudioClip muerte;
public AudioClip muerteEnemigo;
public AudioClip muerteJefe;
public AudioClip reciboDano;
public AudioClip danando;
public AudioClip habEspecial;
public AudioClip caminando;
public AudioClip maquinaExp;
public AudioClip itemMaquina;
public AudioClip dineroRecoger;
public AudioClip vidaRecoger;
public AudioClip itemRecoger;


public static AudioManager Instance;



    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = lobby;
        audioSource.Play();
        
    }

    void Update()
    {
        //Para que no se solapen reproducciones con cosas que suceden en Start()
        if (Instance != null && Instance != this){
            Destroy(this.gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }


    //Cuando suenen los personajes hablando
    public void SuenaChurro() {
        audioSource.PlayOneShot(churroHabla);
    }

    public void SuenaBunuelo() {
        audioSource.PlayOneShot(bunueloHabla);
    }

    public void SuenaNapo() {
        audioSource.PlayOneShot(napoHabla);
    }

    public void SuenaYoriq() {
        audioSource.PlayOneShot(yoriqHabla);
    }


    //Cuando suene un ataque propio
    public void Atacando() {
        audioSource.PlayOneShot(atacando);
    }

    //Cuando suene un ataque enemigo
    public void Atacan() {
        audioSource.PlayOneShot(atacan);
    }

    //Cuando muera un enemigo
    public void MuerteEnemigo() {
        audioSource.PlayOneShot(muerteEnemigo);
    }

    //Cuando suene el player reciba daño
    public void ReciboDaño() {
        audioSource.PlayOneShot(reciboDano);
    }

    //Cuando suene un enemigo reciba daño
    public void Dañando() {
        audioSource.PlayOneShot(danando);
    }

    //Cuando suene el player muera
    public void Muerte() {
        audioSource.PlayOneShot(muerte);
    }

    //Cuando muera un jefe
    public void MuerteJefe() {
        audioSource.PlayOneShot(muerteJefe);
    }

    //Cuando el player use la habilidad especial
    public void HabEspecial() {
        audioSource.PlayOneShot(habEspecial);
    }

    //Cuando suene el player camine
    public void Caminando() {
        audioSource.PlayOneShot(caminando);
    }

    //Cuando se use la máquina expendedora
    public void MaquinaExp() {
        audioSource.PlayOneShot(maquinaExp);
    }

    //Cuando un item caiga de la maquina
    public void ItemMaquina() {
        audioSource.PlayOneShot(itemMaquina);
    }

    //Cuando se recoja un item
    public void ItemRecoger() {
        audioSource.PlayOneShot(itemRecoger);
    }

    //Cuando se consiga una vida
    public void VidaRecoger() {
        audioSource.PlayOneShot(vidaRecoger);
    }

    //Cuando se consiga dinero
    public void DineroRecoger() {
        audioSource.PlayOneShot(dineroRecoger);
    }
}
