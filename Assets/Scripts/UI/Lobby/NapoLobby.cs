using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapoLobby : MonoBehaviour
{
    private Animator napoAnim;

    void Start()
    {
        napoAnim = this.GetComponent<Animator>();
        napoAnim.SetBool("NapoIdle", true);
        napoAnim.SetBool("NapoParada", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
