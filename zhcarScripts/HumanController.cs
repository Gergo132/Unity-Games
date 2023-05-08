using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed = 10;
    Animator animator;
    public GameObject gameManager;
    public int countdown = 30;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 25 && canMove == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    IEnumerator Countdown()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1);
            countdown--;
        }
        canMove= true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
