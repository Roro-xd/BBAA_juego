using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrianaLobby : MonoBehaviour
{
    private Animator adrianaAnim;

    void Start()
    {
        //Solo para establecerle una animación concreta de esta escena
        adrianaAnim = this.GetComponent<Animator>();
        adrianaAnim.SetBool("A_Inquieta", true);
    }
}
