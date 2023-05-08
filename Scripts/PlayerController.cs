using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, rotationSpeed;
  //public int maxCoins;
    int counter = 0;
    public GameObject gameManager;
    public CoinSpawner coinSpawner;


    private void Start()
    {
      //maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        gameManager = GameObject.Find("GameManager");
        coinSpawner = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);     

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinSpawner.CoinTaken();
            other.gameObject.SetActive(false);
            counter++;
            if (counter == 5)
            {
                gameManager?.GetComponent<GameManager>().GameOver();
            }
        }
    }
}
