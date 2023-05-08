using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private CharacterController controller;
    public GameManager gm;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        gm = GameObject.Find("GameManager")?.GetComponent<GameManager>();
    }

    public void PlayDie()
    {
        animator.SetTrigger("Die_trig");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        controller.SimpleMove(dir * speed);

        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("Walk_b", false);
            transform.forward = -dir;
        } else
        {
            animator.SetBool("Walk_b", true);
        }
    }
}
