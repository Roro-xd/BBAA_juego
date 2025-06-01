using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosExtras : MonoBehaviour
{

    //TABLA DE ENEMIGOS
    public GameObject[] enemigos;
    public int selectedEnemigo = 0;

    //Movimiento de la tabla de enemigos
    public GameObject flachePrev;
    public GameObject flacheNext;


    void Update()
    {
        //No poder ir hacia atrás en el primero que salga (básicamente, no dejar ir del primero al último)
        if (selectedEnemigo == 0)
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(false);
        }
        //No poder ir hacia delante en el último que salga (básicamente, no dejar ir del último al primero)
        else if (selectedEnemigo == 3)
        {
            flachePrev.SetActive(true);
            flacheNext.SetActive(false);
        }
        //Tener ambas posibilidades en cualquier otro caso
        else
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(true);
        }
    }

    public void NextEnemigo()
    {
        enemigos[selectedEnemigo].SetActive(false);
        selectedEnemigo = (selectedEnemigo + 1) % enemigos.Length;
        enemigos[selectedEnemigo].SetActive(true);
    }


    public void PrevEnemigo()
    {
        enemigos[selectedEnemigo].SetActive(false);
        selectedEnemigo--;
        if (selectedEnemigo < 0)
        {
            selectedEnemigo += enemigos.Length;
        }

        enemigos[selectedEnemigo].SetActive(true);
    }
}
