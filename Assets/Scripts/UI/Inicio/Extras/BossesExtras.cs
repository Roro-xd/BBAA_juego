using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesExtras : MonoBehaviour
{
 
    //TABLA DE BOSSES
    public GameObject[] bosses;
    public int selectedBoss = 0;

    //Movimiento de la tabla de bosses
    public GameObject flachePrev;
    public GameObject flacheNext;


    void Update()
    {
        //No poder ir hacia atrás en el primero que salga (básicamente, no dejar ir del primero al último)
        if (selectedBoss == 0)
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(false);
        }
        //No poder ir hacia delante en el último que salga (básicamente, no dejar ir del último al primero)
        else if (selectedBoss == 2)
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


    public void NextBoss()
    {
        bosses[selectedBoss].SetActive(false);
        selectedBoss = (selectedBoss + 1) % bosses.Length;
        bosses[selectedBoss].SetActive(true);
    }


    public void PrevBoss()
    {
        bosses[selectedBoss].SetActive(false);
        selectedBoss--;
        if (selectedBoss < 0)
        {
            selectedBoss += bosses.Length;
        }

        bosses[selectedBoss].SetActive(true);
    }
}
