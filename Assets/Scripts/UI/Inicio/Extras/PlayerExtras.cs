using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExtras : MonoBehaviour
{

    public GameObject[] players;
    public int selectedPlayer = 3;


    public void NextPlayer()
    {
        players[selectedPlayer].SetActive(false);
        selectedPlayer = (selectedPlayer + 1) % players.Length;
        players[selectedPlayer].SetActive(true);
    }


    public void PrevPlayer()
    {
        players[selectedPlayer].SetActive(false);
        selectedPlayer--;
        if (selectedPlayer < 0)
        {
            selectedPlayer += players.Length;
        }

        players[selectedPlayer].SetActive(true);
    }
    
}
