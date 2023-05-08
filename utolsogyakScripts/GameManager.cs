using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        player.GetComponent<PlayerController>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        //gameOverText.SetText("You lost");
        gameOverText.SetText(gameOverText.text + "!!!");
        StartCoroutine(StartRestartMethod());
        gameOverUI.SetActive(true);
    }


    IEnumerator StartRestartMethod()
    {
        while (!Input.GetKeyDown(KeyCode.R))
        {
            yield return null;
        }
        Debug.Log("Restarted...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Restart();

    }

    public void Restart()
    {

    }
}
