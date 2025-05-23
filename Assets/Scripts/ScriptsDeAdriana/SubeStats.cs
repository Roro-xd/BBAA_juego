using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeStats : MonoBehaviour
{
    public int aumentaVidaMax = 0;
    public float reduceCooldownAtaque = 0f;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
