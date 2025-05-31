using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infosElevMaq : MonoBehaviour
{
    public GameObject expElev;
    public Camera camara;

    void Start()
    {
        if (expElev != null)
        {
            expElev.SetActive(false); // Ocultar el mensaje al inicio
        }
    }

    void Update()
    {
        Vector2 posicionMouse = camara.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(posicionMouse, Vector2.zero);

        if (hit.collider != null && hit.collider == GetComponent<Collider2D>())
        {
            expElev.SetActive(true);
        }
        else
        {
            expElev.SetActive(false);
        }
    }
}
