using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecución : MonoBehaviour
{
    public GameObject player;
    public bool siPersigue = true;

    public float velocidadAtac = 1; //velocidad a la que te persigue

    Vector3 direccionMov;//vector de movimiento del enemigo

    public float tiempoEspera = 1f;

    public bool siEspera = false;

    public bool siHerido=false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (siPersigue == true)
        {

            direccionMov = Vector3.MoveTowards(transform.position, player.transform.position, velocidadAtac * Time.deltaTime);

            transform.position = direccionMov; //se m ueve hacia jugador
           

            //voltea el sprite en dirección al jugador
            if (player.transform.position.x <= transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else { this.GetComponent<SpriteRenderer>().flipX = true; }
        }

        if (siHerido == true)
        {
            Herido();
        }



    }

    void Herido()
    {
        if (siEspera == false)
        {   siPersigue=false; 
            StartCoroutine(TiempoReaccion());
            transform.Translate( direccionMov  *-1);
            siEspera = true;
            this.GetComponent<SpriteRenderer>().color=Color.red;
        }

    }

    IEnumerator TiempoReaccion()
    {
        yield return new WaitForSeconds(tiempoEspera);
        transform.position = direccionMov;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        siEspera = false;
        siHerido = false;
        siPersigue =true;
    }
    
}
