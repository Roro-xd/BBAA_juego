using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Outline : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<SpriteRenderer>().sprite;
        transform.localScale = new Vector2(5f, 1.2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
