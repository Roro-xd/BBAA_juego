using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaExpendedora : MonoBehaviour
{
    public List<GameObject> objetosDisponibles; // Lista editable desde el Inspector
    public Transform puntoDeSpawn;
    public float duracionVibracion = 0.5f;
    public float intensidadVibracion = 0.1f;

    private bool enUso = false;
    private Vector3 posicionOriginal;

    private void Start()
    {
        posicionOriginal = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enUso) return;
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivarMaquina());
        }
    }

    private IEnumerator ActivarMaquina()
    {
        enUso = true;

        // Vibración
        float tiempo = 0f;
        while (tiempo < duracionVibracion)
        {
            Vector3 offset = new Vector3(
                Random.Range(-intensidadVibracion, intensidadVibracion),
                Random.Range(-intensidadVibracion, intensidadVibracion),
                0f
            );
            transform.position = posicionOriginal + offset;
            tiempo += Time.deltaTime;
            yield return null;
        }

        transform.position = posicionOriginal;

        // Soltar objeto sin repetir
        if (objetosDisponibles.Count > 0)
        {
            int indice = Random.Range(0, objetosDisponibles.Count);
            GameObject objetoSeleccionado = objetosDisponibles[indice];

            Instantiate(objetoSeleccionado, puntoDeSpawn.position, Quaternion.identity);
            objetosDisponibles.RemoveAt(indice); // Eliminar para que no se repita
        }
        else
        {
            Debug.Log("La máquina expendedora ya no tiene objetos.");
        }

        enUso = false;
    }
}