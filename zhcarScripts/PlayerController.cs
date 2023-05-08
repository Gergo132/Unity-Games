using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, rotationSpeed;
    public GameObject gameManager;
    int score = 0;
    Vector3 prev_position;

    private void Start()
    {
        prev_position= transform.position;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);     

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            gameManager.GetComponent<GameManager>().minusLife();
            transform.position = prev_position;

            if (gameManager.GetComponent<GameManager>().lives == 0) {
                gameManager.GetComponent<GameManager>().GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin");
        score++;
        speed *= 1.5f;
        prev_position = transform.position;
        other.gameObject.SetActive(false);
        if (score == 5) {
            gameManager.GetComponent<GameManager>().Win();
        }
    }


}
