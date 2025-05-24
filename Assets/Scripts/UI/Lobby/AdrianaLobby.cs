using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrianaLobby : MonoBehaviour
{
    private Animator adrianaAnim;

    void Start()
    {
        adrianaAnim = this.GetComponent<Animator>();
        adrianaAnim.SetBool("A_Inquieta", true);
        //adrianaAnim.SetBool("A_Inquieta", true);
    }

    void Update()
    {
        
    }
}
