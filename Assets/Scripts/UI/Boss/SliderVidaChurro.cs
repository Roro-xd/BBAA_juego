using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVidaChurro : MonoBehaviour
{
    public GameObject churro;
    private float vidaChurro;
    void Start()
    {
        vidaChurro = churro.GetComponent<VidaJefe>().vidaActual;
    }

    void Update()
    {
        //this.gameObject.GetComponent<Slider>().value = vidaChurro;
    }

    public void OnValueChanged()
    { 
        this.gameObject.GetComponent<Slider>().value = vidaChurro;
    }
}
