using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    public float boost = 10;
    private GameObject focalPoint;
    
    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; //qué tan difícil golpear al enemigo sin poder
    private float powerupStrength = 25; //qué tan difícil golpear al enemigo con powerup

    public ParticleSystem boostParticles;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");



    }

    void Update()
    {
        // Agregue fuerza al jugador en la dirección del punto focal (y la cámara)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

        // Establezca la posición del indicador de encendido debajo de la reproductor
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        
        Boost();

    }

    // Si la jugadora choca con el encendido, activa el encendido
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());


        }
    }

    // Corutina para contar la duración del encendido
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // Si la jugadora choca con la enemiga
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (hasPowerup) // si el powerup golpea al enemigo con fuerza de powerup
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // si no hay encendido, golpea al enemigo con fuerza normal
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }

    void Boost() {
        if (Input.GetKeyDown("space"))
        {
            // da un 'impulso'
            playerRb.AddForce(focalPoint.transform.forward * boost, ForceMode.Impulse);
            boostParticles.Play();

        }

    }

}
