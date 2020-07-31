using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    
    //asegura que no puedas subir si estás por encima de la altura máxima.
    private bool isLowEnough = true;
    private float maxheight = 15;

    //la cantidad de fuerza con la que el globo se dispara cuando toca el suelo
    private float bounceForce = 20;
    
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    //Se llama al inicio antes de la primera actualización del marco
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Aplica una pequeña fuerza hacia arriba al comienzo del juego
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    //La actualización se llama una vez por fotograma
    void Update()
    {
        //Mientras se presiona el espacio y el jugador está lo suficientemente bajo, flota
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        
        hoogtelimiet();
        
    }

    private void hoogtelimiet()
    {
        if (transform.position.y > maxheight)
        {
            isLowEnough = false;
        }
        
        else if (transform.position.x < maxheight)
        {
            isLowEnough = true;
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
        //si el jugador choca con la bomba, explota y establece el juego en verdadero
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // si el jugador choca con dinero, fuegos artificiales
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        
        if (other.gameObject.CompareTag("Ground"))
        {

            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }

    }

}
