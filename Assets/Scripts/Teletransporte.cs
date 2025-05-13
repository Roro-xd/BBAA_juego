using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject jugador;
    public GameObject destino;
    public bool meTransporto = false;
    public float distanciax = 1f;
    public float distanciay = 1f;


    // Start is called before the first frame update
    void Start()
    {
      jugador = GameObject.FindWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*Para que este Script funcione:
  -El gameObject y el Player deben tener RigidBody2D y Collider2D
  -El Player:
    En Collider2D es Trigger
    En RigidBody2D es Body type Kinematic
  -El GameObject:
    En Collider2D NO es Trigger
    En RigidBody2D  es Body Type Static

*/
   void OnTriggerEnter2D(Collider2D col){
      if (meTransporto==false){
        jugador.transform.position = new Vector3 (destino.transform.position.x + distanciax,destino.transform.position.y+distanciay,destino.transform.position.z);
       meTransporto = true;}
    }
     void OnTriggerExit2D()
    {
        if(meTransporto == true) {meTransporto=false;}
        
    } 
}
