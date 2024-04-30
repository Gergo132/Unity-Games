using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int coinCounter = 0;
    private int maxCoins;
    [SerializeField] private TMPro.TextMeshProUGUI gameOverText,
        coinText, timeText;
    int timeLeft = 10;

    private void Start()
    {
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("maxCoins: " +  maxCoins);
        gameOverText.gameObject.SetActive(false);
        coinText.SetText("Coins: " + coinCounter + "/" + maxCoins);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timeText.SetText(timeLeft.ToString());
        }
        GameOver(false);
    }

    public void CoinPickedUp()
    {
        coinCounter++;
        coinText.SetText("Coins: " + coinCounter + "/" + maxCoins);
    
        Debug.Log("Coins: " + coinCounter);
        if(coinCounter == maxCoins)
        {
            Debug.Log("You won!");
            GameOver(true);
        }
    }
    public void GameOver(bool isWin)
    {
        GameObject.FindObjectOfType<PlayerController>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        if (!isWin)
        {
            gameOverText.SetText("Game Over");
        }
        Time.timeScale = 0;
    }
}
