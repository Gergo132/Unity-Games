using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI timeText, gameOver;
    public int timeLeft;
    //IEnumerator countdown;


    private void Start()
    {
        timeText.SetText("Time: " + timeLeft);
        //countdown = Countdown();
        StartCoroutine(Countdown());
        gameOver.gameObject.SetActive(false);
    }
    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timeText.SetText("Time: " + timeLeft);
        }
        GameOver();
    }
    public void GameOver()
    {
        player.GetComponent<PlayerController>().enabled = false;
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        //StopCoroutine(Countdown());
    }
}
