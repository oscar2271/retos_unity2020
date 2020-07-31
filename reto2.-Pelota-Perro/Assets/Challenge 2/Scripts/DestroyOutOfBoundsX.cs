using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    //  La actualización se llama una vez por fotograma
    void Update()
    {
        // Destruir perros si la posición x es inferior al límite izquierdo
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destruya las bolas si la posición y es menor que el límite inferior
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
