using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;
    // La actualización se llama una vez por fotograma
    void Update()
    {
        // En la barra espaciadora presione, enviar perro
        //Cuenta el tiempo transcurrido del juego y agrega velocidad de fuego al flotador de Nextfire cada vez que lo usas..
        //Esto asegura que siempre haya un tiempo de espera de 2 segundos.
        if (Input.GetKeyDown(KeyCode.Space) &&  Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
