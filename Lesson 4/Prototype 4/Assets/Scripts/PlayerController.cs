using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public bool hasPowerup;
    public float powerupStrength = 15.0f;

    private Rigidbody playerRb;

    private GameObject focalPoint;  

    public GameObject powerupIdicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");

        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.right * speed * sideInput);

        powerupIdicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        powerupIdicator.transform.Rotate(Vector3.up * 40 * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIdicator.gameObject.SetActive(hasPowerup);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIdicator.gameObject.SetActive(hasPowerup);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayDirection * powerupStrength, ForceMode.Impulse);

            Debug.Log("Collided with:" + collision.gameObject.name + " with powerup set to:" + hasPowerup);
            
        }
    }
}
