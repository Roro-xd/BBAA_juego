using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{



    //Referencia a los sliders
    public Slider musicaSlider, sfxSlider, vocesSlider;

    public GameObject panelVolumen;

    /*public void GuardarVolMusica(float newValue) ///////PREGUNTAR SI SE HACE ASÍ --- para guardar el valor
    {
        PlayerPrefs.SetFloat("MusicaGuardada", musicaSlider.value);
        PlayerPrefs.Save();
    }

    public void CargarVolMusica()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("MusicaGuardada", 1f);
    }*/





    //RELACIONAR CADA VOLUMEN CON SU SLIDER
    public void VolMusica(float volumen)
    {
        AudioManager.Instance.VolMusica(musicaSlider.value);
    }

    public void VolSFX(float volumen)
    {
        AudioManager.Instance.VolSFX(sfxSlider.value);
    }
    
    public void VolVoces(float volumen)
    { 
        AudioManager.Instance.VolVoces(vocesSlider.value);
    }
}
