using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position; // Establecer la posición inicial predeterminada

        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //Establezca el ancho de repetición a la mitad del fondo
    }

    private void Update()
    {
        // Si el fondo se mueve hacia la izquierda por su ancho de repetición, muévalo hacia atrás a la posición inicial
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}


