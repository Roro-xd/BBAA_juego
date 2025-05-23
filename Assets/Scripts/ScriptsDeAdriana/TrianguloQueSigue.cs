using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloQueSigue : MonoBehaviour
{
    public new Camera camera;
    public Transform spawner;
    private SpriteRenderer spriteRenderer;

    private Animator animator;

     private Color colorOriginal;
    public GameObject player;

    bool siAtaco = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        RotateTowardsMouse();
        CheckFiring();

        
    }

    private void RotateTowardsMouse()
    {
        float angle = GetAngleTowardsMouse();

        transform.rotation = Quaternion.Euler(0, 0, angle);
        spriteRenderer.flipY = angle >= 90 && angle <= 270;
    }

    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;

        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }

    private void CheckFiring()
    {
        //si se puede aracar se pone a color, si no en gris
        if (player.GetComponent<AtaqueMelee>().siPuedoAtacar == false && siAtaco==false)
        {
            this.spriteRenderer.color = Color.gray;
        }
        else if (player.GetComponent<AtaqueMelee>().siPuedoAtacar == false && siAtaco == true && player.GetComponent<AtaqueMelee>().siAcierta== false) { spriteRenderer.color = colorOriginal; }
        else if (player.GetComponent<AtaqueMelee>().siPuedoAtacar == false && siAtaco == true && player.GetComponent<AtaqueMelee>().siAcierta== true) { spriteRenderer.color = Color.yellow; }
        else if (player.GetComponent<AtaqueMelee>().siPuedoAtacar == true) { this.spriteRenderer.color = colorOriginal; }
        

        if (Input.GetMouseButtonDown(0))
        {
            if (siAtaco == false)
            {
                siAtaco = true;
                animator.SetBool("siAtaca", true);
                StartCoroutine(Ataque());
            }
        }
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = colorOriginal;
        siAtaco = false;
        animator.SetBool("siAtaca", false) ;
    }
}

