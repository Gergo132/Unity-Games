using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI chooseVText;
    public int time;
    public GameObject carPrefab, busPrefab;
    bool isPlayerChosen;
    public FollowPlayer fp;

    void Start()
    {
        //timeText.SetText("Time: " + time);
        chooseVText.gameObject.SetActive(true);
    }

    IEnumerator Countup()
    {
        //yield return new WaitUntil(() => isPlayerChosen);
        while (time >= 0)
        {
            yield return new WaitForSeconds(1);
            time++;
            timeText.SetText("Time: " + time);
        }
    }

    void Update()
    {
        if(!isPlayerChosen)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player = Instantiate(carPrefab, new Vector3(0,0,0), Quaternion.identity);
                fp.Setup(player);
                isPlayerChosen = true;
                chooseVText.gameObject.SetActive(false);
                StartCoroutine(Countup());

                //SetPlayerForCamera(player);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player = Instantiate(busPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                fp.Setup(player);
                isPlayerChosen = true;
                chooseVText.gameObject.SetActive(false);
                StartCoroutine(Countup());

                //SetPlayerForCamera(player);
            }
        }
    }

    //void SetPlayerForCamera(GameObject newPlayer)
    //{
    //    var camera = FindObjectOfType<FollowPlayer>();
    //    camera.player = newPlayer;
    //}

    public void GameOver()
    {
        player.GetComponent<PlayerController>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        StopAllCoroutines();

    }
}
