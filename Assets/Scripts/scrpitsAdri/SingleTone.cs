using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SingleTone : MonoBehaviour
{
    public static SingleTone Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
    
    