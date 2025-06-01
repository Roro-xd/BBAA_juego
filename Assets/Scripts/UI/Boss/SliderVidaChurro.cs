using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVidaChurro : MonoBehaviour
{

    //Nombro a Churro y su vida
    public GameObject churro;
    private float vidaChurro;


    void Start()
    {
        //Enlazo mi variable de la vida de Churro con la que está en su objeto
        vidaChurro = churro.GetComponent<VidaJefe>().vidaActual;
    }


    void Update()
    {
        //this.gameObject.GetComponent<Slider>().value = vidaChurro;
    }


    //Cambiar el valor del slider según la vida de Churro
    public void OnValueChanged()
    {
        vidaChurro = this.GetComponent<Slider>().value;
    }
}
