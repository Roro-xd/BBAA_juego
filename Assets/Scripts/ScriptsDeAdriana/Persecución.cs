using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persecución : MonoBehaviour
{
    public GameObject player;
    public bool siPersigue = true;

    public float velocidadAtac = 1; //velocidad a la que te persigue
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    if (siPersigue==true){

        transform.position= Vector3.MoveTowards(transform.position, player.transform.position,velocidadAtac*Time.deltaTime); //se m ueve hacia jugador
        
        //voltea el sprite en dirección al jugador
        if (player.transform.position.x <= transform.position.x)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else { this.GetComponent<SpriteRenderer>().flipX = true; }
    }
    }
}
