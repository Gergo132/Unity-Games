using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    int countdown = 3;
    public TextMeshProUGUI countDown;
    public GameObject player;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public int lives = 3;
    public GameObject Coin;
    int z_min = 9;
    int z_max = 160;
    int x_min = -25;
    int x_max = 25;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Invoke("spawnCoin", 0.0f);
        }
        player.GetComponent<PlayerController>().enabled = false;
        countDown.SetText(countdown.ToString());
        StartCoroutine(Countdown());
    }

    void spawnCoin() 
    {
        float x = Random.Range(x_min, x_max);
        float z = Random.Range(z_min, z_max);
        Instantiate(Coin, new Vector3(x, 2, z), Coin.transform.rotation);
    }

    IEnumerator Countdown()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1);
            countdown--;
            countDown.SetText(countdown.ToString());
        }

        if (countdown == 0) {
            countDown.SetText("Go!");
            player.GetComponent<PlayerController>().enabled = true;
        }

        countDown.gameObject.SetActive(false);
    }

    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void Win()
    {
        winText.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void minusLife()
    {
        lives--;
        livesText.SetText("Lives:" + lives + "/3");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
