using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoRelaciones : MonoBehaviour
{
    //Elemento que va desaparecer/aparecer + cámara para detectar posición del puntero
    public GameObject explicacionRel;
    public Camera camara;


    void Start()
    {
        //Ocultar explicación al inicio
        if (explicacionRel != null)
        {
            explicacionRel.SetActive(false);
        }
    }


    void Update()
    {
        //Si entra en contacto con el este trigger, que aparezca; cuando deje de estar en contacto, desaparece
        Vector2 posicionMouse = camara.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(posicionMouse, Vector2.zero);

        if (hit.collider != null && hit.collider == GetComponent<Collider2D>())
        {
            explicacionRel.SetActive(true);
        }
        else
        {
            explicacionRel.SetActive(false);
        }
    }
}
