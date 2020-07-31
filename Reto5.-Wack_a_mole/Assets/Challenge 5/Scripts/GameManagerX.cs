using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;

    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f; //  valor x del centro del cuadrado más a la izquierda
    private float minValueY = -3.75f; //  valor y del centro del cuadrado más inferior
    
    


    public TextMeshProUGUI timerText;
    float timeLeft = 60.0f;

    // Inicie el juego, elimine la pantalla de título, restablezca la puntuación y ajuste spawnRate según el botón de dificultad al hacer clic

    // cambiar la frecuencia de generación a la dificultad de los botones
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);


    }

    // Mientras el juego está activo, genera un objetivo aleatorio
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }

        }
    }

    // Genere una posición de generación aleatoria basada en un índice aleatorio de 0 a 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Genera un índice cuadrado aleatorio de 0 a 3, que determina en qué cuadrado aparecerá el objetivo
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Actualizar puntaje con valor del objetivo en el que se hizo clic
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Detener el juego, abrir el juego sobre el texto y reiniciar el botón
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Reinicia el juego volviendo a cargar la escena.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Update()
    {
        if (isGameActive)
        {
            //sostiene el gelopen tijd van de time Izquierdo (60 segundos) af
            timeLeft -= Time.deltaTime;
            timerText.SetText("Time: " + Mathf.Round(timeLeft));
            if (timeLeft < 0)
                // gameover
            {
                GameOver();

            }
        }
    }
}
