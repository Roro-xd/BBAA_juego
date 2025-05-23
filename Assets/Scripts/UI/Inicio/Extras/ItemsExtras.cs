using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsExtras : MonoBehaviour
{

    public GameObject[] items;
    public int selectedItem = 0;

    public GameObject flachePrev;
    public GameObject flacheNext;


    void Update()
    {
        if (selectedItem == 0)
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(false);
        }
        else if (selectedItem == 18)
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
