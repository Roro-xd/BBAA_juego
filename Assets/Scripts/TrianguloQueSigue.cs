using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianguloQueSigue : MonoBehaviour
{
    public new Camera camera;
    public Transform spawner;
    private SpriteRenderer spriteRenderer;

     private Color colorOriginal;

    bool siAtaco = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
         colorOriginal = spriteRenderer.color;
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
        if (Input.GetMouseButtonDown(0))
        {
            if (siAtaco == false)
            {
                spriteRenderer.color = Color.yellow;
                siAtaco = true;
                StartCoroutine(Ataque()) ;
            }
        }
    }

    IEnumerator Ataque()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = colorOriginal;
        siAtaco = false;
    }
}

