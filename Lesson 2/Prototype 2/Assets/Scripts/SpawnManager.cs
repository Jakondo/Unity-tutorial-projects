using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private int spawnRangeX = 20;
    private int spawnPosZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    void SpawnRandomAnimal()
    {
        /* 
            * Рандомный выбор одного элемента массива
            * var animalIndex = new System.Random().Next(animalPrefabs.Count());
        */
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);

        // Создание нового вектора (x,y,z) со случайными значениями Х в заданном диапазоне
        Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

}
