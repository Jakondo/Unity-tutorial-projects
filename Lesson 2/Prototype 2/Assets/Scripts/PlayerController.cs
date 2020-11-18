using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    // Параметры скорости передвижения игрока и крайние значения области передвижения
    private float speed = 15.0f;
    private int[] maxValues = { -15, 15 };

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Проверка на достижение крайних точек игровой области игроком
        CheckForBorder();

        // Инициализация перемещения игрока по игровому полю
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Запуск снарядов
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

    private void CheckForBorder()
    {
        if (transform.position.x < maxValues[0])
        {
            transform.position = new Vector3(maxValues[0], transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxValues[1])
        {
            transform.position = new Vector3(maxValues[1], transform.position.y, transform.position.z);
        }
    }

    private void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
