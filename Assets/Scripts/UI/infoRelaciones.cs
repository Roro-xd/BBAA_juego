using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoRelaciones : MonoBehaviour
{
    public GameObject explicacionRel;
    public Camera camara;

    void Start()
    {
        if (explicacionRel != null)
        {
            explicacionRel.SetActive(false); // Ocultar el mensaje al inicio
        }
    }

    void Update()
    {
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
