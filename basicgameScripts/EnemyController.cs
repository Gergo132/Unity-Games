using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject bullet;
    public GameObject player;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 5)
            {
                yield return new WaitForSeconds(2);
                GameObject newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);
                newBullet.transform.forward = player.transform.position - transform.position;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            gameManager?.GetComponent<GameManager>().GameOver();
        }
    }
}
