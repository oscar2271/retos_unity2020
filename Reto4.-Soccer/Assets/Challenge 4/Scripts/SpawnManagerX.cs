using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // establecer min spawn Z
    private float spawnZMax = 25; // establecer max spawn Z

    public int enemyCount;
    public int waveCount = 1;


    public GameObject player;
    public float enemySpeed = 50;

    // La actualización se llama una vez por fotograma
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
            waveCount++;
            enemySpeed++;
        }

    }

    // Genera una posición de generación aleatoria para potenciadores y bolas enemigas
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // Si no quedan poderes especiales, genera un poder
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Genera el número de bolas enemigas según el número de ola
        //enemigosToSpawn debe ser en lugar de 2 para que el número aumente en cada ronda
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
        ResetPlayerPosition(); // poner al jugador de vuelta al inicio

    }

    // Mueve a la jugadora de vuelta a la posición delante de la propia meta
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
