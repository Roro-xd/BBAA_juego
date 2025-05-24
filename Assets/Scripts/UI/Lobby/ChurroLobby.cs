using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurroLobby : MonoBehaviour
{
    private Animator churroAnim;

    void Start()
    {
        churroAnim = this.GetComponent<Animator>();
        churroAnim.SetBool("ChurroIdle", true);
        churroAnim.SetBool("ChurroParado", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
