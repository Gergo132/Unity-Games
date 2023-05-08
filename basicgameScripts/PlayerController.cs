using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        transform.Translate(dir * Time.deltaTime * speed);
        //transform.forward = dir;

        if(horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Walk_b", true);
        }
        else
        {
            animator.SetBool("Walk_b", false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
