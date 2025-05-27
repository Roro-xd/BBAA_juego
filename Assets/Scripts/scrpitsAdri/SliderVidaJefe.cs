using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SliderVidaJefe : MonoBehaviour
{
    public Slider slider;
    public VidaJefe vidaJefe; // Referencia al script de vida del jefe

    void Start()
    {
        if (vidaJefe != null && slider != null)
        {
            slider.maxValue = vidaJefe.vidaMaxima;
            slider.value = vidaJefe.vidaActual;
        }
    }

    void Update()
    {
        if (vidaJefe != null && slider != null)
        {
            slider.value = vidaJefe.vidaActual;
        }
    }
}