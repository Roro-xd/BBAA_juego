using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsExtras : MonoBehaviour
{

    //TABLA DE ITEMS
    public GameObject[] items;
    public int selectedItem = 0;

    //Movimiento de la tabla de ítems
    public GameObject flachePrev;
    public GameObject flacheNext;


    void Update()
    {
        //No poder ir hacia atrás en el primero que salga (básicamente, no dejar ir del primero al último)
        if (selectedItem == 0)
        {
            flacheNext.SetActive(true);
            flachePrev.SetActive(false);
        }
        //No poder ir hacia delante en el último que salga (básicamente, no dejar ir del último al primero)
        else if (selectedItem == 18)
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
