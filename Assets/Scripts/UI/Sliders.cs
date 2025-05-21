using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider musicaSlider, sfxSlider, vocesSlider;

    /*public void GuardarVolMusica(float newValue)
    {
        PlayerPrefs.SetFloat("MusicaGuardada", musicaSlider.value);
        PlayerPrefs.Save();
    }

    public void CargarVolMusica()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("MusicaGuardada", 1f);
    }*/

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
