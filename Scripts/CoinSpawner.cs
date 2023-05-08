using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    int coinCount = 0;
    public int maxCoins = 5;

    void Start()
    {
        SpawnCoin();
    }

    public void CoinTaken()
    {
        coinCount--;
        if (coinCount == 0)
        {
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        if (coinCount >= maxCoins)
        {
            return;
        }

        float x = Random.Range(-30f, 30f);
        float y = 1f;
        float z = Random.Range(-14f, 180f);

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        coinCount++;

        //if(coinCount >= maxCoins)
        //{
        //    GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        //    foreach (GameObject coin in coins)
        //    {
        //        Destroy(coin);
        //    }
        //}
    }
}

