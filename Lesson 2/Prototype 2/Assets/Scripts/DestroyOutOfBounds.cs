using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float botBound = -30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
         Проверка на достижение границы поля:
            Если достигнуто верхнее поле, то объект удаляется.
            Если достигнуто нижнее поле, то объект удаляется и выводится сообщение в Log о завершении игры.
         */
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < botBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }

    }
}
