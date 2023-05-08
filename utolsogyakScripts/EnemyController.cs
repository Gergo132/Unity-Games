using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject gameManager, player;
    PlayerController playerController;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.PlayDie();
            gameManager?.GetComponent<GameManager>()?.GameOver();
        }
    }
}
