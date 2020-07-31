using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    //  La actualización se llama una vez por fotograma
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
