using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 2.0f;



    private void Update()
    {


    }

    // Se llama al inicio antes de la primera actualización del marco
    void Start()
    {
        Invoke("SpawnRandomBall",  startDelay);
    }

    // Engendrar bolas al azar
    void SpawnRandomBall ()
    {

        //asegura que las bolas se generen al azar
        float spawnInterval = Random.Range(3.0f, 5.0f);
        
        //posición x aleatoria en la parte superior del área de juego
        int index = Random.Range(0, ballPrefabs.Length);
        // Generar índice de bola aleatorio y posición de generación aleatoria
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instanciar la bola en un lugar de generación aleatorio
        Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
        Invoke("SpawnRandomBall",  spawnInterval);
    }
    
    
}
