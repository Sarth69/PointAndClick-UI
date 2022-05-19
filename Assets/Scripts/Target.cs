using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetRb;
    public ParticleSystem explosionParticles;

    public int pointValue;

    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float yRange = 6;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    
        transform.position = RandomStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
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

    private Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 RandomStartPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -yRange);
    }
}
