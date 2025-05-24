using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PruebaAudios : MonoBehaviour
{
    public void IrALevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void IrALevel2()
    {
        SceneManager.LoadScene("Level_2");
    }
    
    public void IrALevel3()
    { 
        SceneManager.LoadScene("Level_3");
    }
}
