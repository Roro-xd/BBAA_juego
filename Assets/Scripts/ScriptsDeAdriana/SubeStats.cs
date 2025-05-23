using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeStats : MonoBehaviour
{

    //todos los valores enteros y float pueden ser negativos para restar en lugar de sumar
    public int aumentaVidaMax = 0; // Cifra  en la que aumenta el valor máximo de vida
    public bool siCuraVidaMax = false; //si a parte de subir la vida máxima la cura al completo
    public float reduceCooldownAtaque = 0f; //en cuantos segundos redece el cooldown de ataque
    public int seCuraTanto = 0; //numero de corazones que cura el objeto
    public float subeVelocidad = 0f; //aumenta la velocidad de caminado
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<AtaqueMelee>().ReducirCooldown(reduceCooldownAtaque); //reduce cooldown de ataque
        player.GetComponent<Vida>().AumentoVidaMax(aumentaVidaMax, siCuraVidaMax); //aumenta la vida max y la cura al max si es el caso
        player.GetComponent<Caminar>().AumentaVelocidad(subeVelocidad); //sube velocidad caminado
        player.GetComponent<Vida>().Curar(seCuraTanto);//se cura según la cantidad dicha

    }
}
