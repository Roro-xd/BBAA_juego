using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Script_dialogos : MonoBehaviour
{

    public GameObject convers;
    private Script_guion_inicio scriptGuion;
    private int selDialogue = 0;
    
    void Start()
    {

        scriptGuion = GetComponent<Script_guion_inicio>();

    }

    void Update()
    {
        selDialogue = scriptGuion.selectedDialogue;
        
        if (selDialogue == 7) //inicio Churro
        {
            AudioManager.Instance.PlayVoces("Churro1");
        } else if (selDialogue == 8)
        {
            AudioManager.Instance.PlayVoces("Churro2");
        } else if (selDialogue == 9)
        {
            AudioManager.Instance.PlayVoces("Churro3");
        } else if (selDialogue == 10) //inicio Buñuelo
        {
            AudioManager.Instance.PlayVoces("Bun1");
        }  else if (selDialogue == 11)
        {
            AudioManager.Instance.PlayVoces("Bun2");
        } else if (selDialogue == 12)
        {
            AudioManager.Instance.PlayVoces("Bun3");
        } else if (selDialogue == 13)
        {
            AudioManager.Instance.PlayVoces("Bun4");
        } else if (selDialogue == 14) //inicio Napo
        {
            AudioManager.Instance.PlayVoces("Napo1");
        } else if (selDialogue == 15)
        {
            AudioManager.Instance.PlayVoces("Napo2");
        } else if (selDialogue == 16) 
        {
            AudioManager.Instance.PlayVoces("Napo3");
        }  else if (selDialogue == 17)
        {
            AudioManager.Instance.PlayVoces("Napo4");
        } else if (selDialogue == 18) //inicio Yoriq
        {
            AudioManager.Instance.PlayVoces("Yor1");
        } else if (selDialogue == 19)
        {
            AudioManager.Instance.PlayVoces("Yor2");
        }


    }
}
