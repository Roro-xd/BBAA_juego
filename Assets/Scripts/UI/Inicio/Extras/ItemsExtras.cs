using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsExtras : MonoBehaviour
{

    public GameObject[] items;
    public int selectedItem = 3;


    public void NextItem()
    {
        items[selectedItem].SetActive(false);
        selectedItem = (selectedItem + 1) % items.Length;
        items[selectedItem].SetActive(true);
    }


    public void PrevItem()
    {
        items[selectedItem].SetActive(false);
        selectedItem--;
        if (selectedItem < 0)
        {
            selectedItem += items.Length;
        }

        items[selectedItem].SetActive(true);
    }
}
