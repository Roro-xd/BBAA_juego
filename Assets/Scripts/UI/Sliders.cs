using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public Slider musicaSlider, sfxSlider, vocesSlider;

    public GameObject[] sliderFondo;
    public int sliderSelect = 0;

    private float incVol = 0.1f;

    public GameObject panelVolumen;

    /*public void GuardarVolMusica(float newValue) ///////PREGUNTAR SI SE HACE ASÍ
    {
        PlayerPrefs.SetFloat("MusicaGuardada", musicaSlider.value);
        PlayerPrefs.Save();
    }

    public void CargarVolMusica()
    {
        musicaSlider.value = PlayerPrefs.GetFloat("MusicaGuardada", 1f);
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && panelVolumen.activeSelf)
        {
            if (sliderSelect == 0)
            {
                musicaSlider.value += incVol;
            }
            else if (sliderSelect == 1)
            {
                sfxSlider.value += incVol;
            }
            else if (sliderSelect == 2)
            {
                vocesSlider.value += incVol;
            }
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && panelVolumen.activeSelf)
        {
            if (sliderSelect == 0)
            {
                musicaSlider.value -= incVol;
            }
            else if (sliderSelect == 1)
            {
                sfxSlider.value -= incVol;
            }
            else if (sliderSelect == 2)
            {
                vocesSlider.value -= incVol;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && panelVolumen.activeSelf)
        {
            RetrasoSlider();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && panelVolumen.activeSelf)
        {
            AvanceSlider();
        }

    }


    public void AvanceSlider()
    {
        sliderFondo[sliderSelect].SetActive(false);
        sliderSelect = (sliderSelect + 1) % sliderFondo.Length;
        sliderFondo[sliderSelect].SetActive(true);
    }

    public void RetrasoSlider()
    {
        sliderFondo[sliderSelect].SetActive(false);
        sliderSelect--;
            if (sliderSelect < 0)
            {
                sliderSelect += sliderFondo.Length;
            }

        sliderFondo[sliderSelect].SetActive(true);
    }


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
