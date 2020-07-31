using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    //público en lugar de privado para que se seleccione el objeto
    public GameObject playerGoal;

    // Se llama al inicio antes de la primera actualización del marco
    
    private SpawnManagerX spawnManagerXScript;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawnManagerXScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        //utiliza para acelerar el valor de enemigo Velocidad desde la secuencia de comandos del administrador de generación
        speed = spawnManagerXScript.enemySpeed;
    }

    //La actualización se llama una vez por fotograma
    void Update()
    {
        //Establece la dirección del enemigo hacia la meta del jugador y muévete allí
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        //Si el enemigo choca con cualquier objetivo, destrúyelo
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            //spawnManagerXScript.waveCount = 1;
            speed = 50;
        }

    }

}
