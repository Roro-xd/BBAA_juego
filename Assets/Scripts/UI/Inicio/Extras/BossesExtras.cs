using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesExtras : MonoBehaviour
{
 
    public GameObject[] bosses;
    public int selectedBoss = 2;


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
