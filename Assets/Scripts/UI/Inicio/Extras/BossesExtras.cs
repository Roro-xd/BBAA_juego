using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesExtras : MonoBehaviour
{
 
    public GameObject[] bosses;
    public int selectedBoss = 0;

    public GameObject flachePrev;
    public GameObject flacheNext;


    void Update()
    {
        if (selectedBoss == 0)
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(false);
        }
        else if (selectedBoss == 2)
        {
            flachePrev.SetActive(true);
            flacheNext.SetActive(false);
        }
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
