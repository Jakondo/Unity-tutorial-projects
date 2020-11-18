using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{    
    public int pointValue;

    private float[] speedRange = { 12, 16 };
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = 3;

    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {        
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        AddRandomForce();
        AddRandomTorque();

        transform.position = GenerateRandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddRandomForce()
    {
        targetRb.AddForce(Vector3.up * Random.Range(speedRange[0], speedRange[1]), ForceMode.Impulse);
    }

    private void AddRandomTorque()
    {
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);
    }

    private Vector3 GenerateRandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos, 0);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            explosionParticle.transform.position = gameObject.transform.position;
            Instantiate(explosionParticle);
            gameManager.UpdateScore(pointValue);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }        
    }

    
}
