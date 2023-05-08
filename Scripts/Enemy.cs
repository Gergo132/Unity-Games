using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float xLimit;
    Animator animator;
    private GameObject gameManager;
    public bool isrunning = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");

        StartCoroutine(StartMovingRandomly());
    }

    IEnumerator StartMovingRandomly()
    {
        float waitTime = Random.Range(1f, 30f);
        yield return new WaitForSeconds(waitTime);

        Indul();
    }

    void Indul()
    {
        isrunning = true;
        animator.SetBool("MoveForward", true);
    }
    void Update()
    {
        if(isrunning && transform.position.x < xLimit)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += speed * Time.deltaTime;
            transform.position = newPosition;
        }
        else
        {
            animator.SetBool("MoveForward", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            gameManager?.GetComponent<GameManager>().GameOver();
        }
    }
}
