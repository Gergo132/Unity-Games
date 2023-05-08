using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject background;
    public TextMeshProUGUI gameOverText;
  
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle,
            new Vector3(25, 0, 0),
            obstacle.transform.rotation);
    }

    public void GameOver()
    {
        CancelInvoke();
        background.GetComponent<RepeatBackground>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        //gameOverText.SetText("game over 2");
        //gameOverText.SetText(gameOverText.text + "!!")
    }



}
