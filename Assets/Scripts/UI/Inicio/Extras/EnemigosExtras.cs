using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosExtras : MonoBehaviour
{
    public GameObject[] enemigos;
    public int selectedEnemigo = 3;


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
