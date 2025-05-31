using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoMaq : MonoBehaviour
{
    public GameObject expMaq;
    public Camera camara;

    void Start()
    {
        if (expMaq != null)
        {
            expMaq.SetActive(false); // Ocultar el mensaje al inicio
        }
    }

    void Update()
    {
        Vector2 posicionMouse = camara.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(posicionMouse, Vector2.zero);

        if (hit.collider != null && hit.collider == GetComponent<Collider2D>())
        {
            expMaq.SetActive(true);
        }
        else
        {
            expMaq.SetActive(false);
        }
    }
}
