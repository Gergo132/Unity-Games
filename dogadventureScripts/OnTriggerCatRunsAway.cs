using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OnTriggerCatRunsAway : MonoBehaviour
{
    public GameObject Cat;
    public float speed;
    public bool dogNear = false;
    Animator animator;
    public GameObject CatHair;

    private void Start()
    {
        animator = Cat.GetComponent<Animator>();
        animator.enabled = false;
        CatHair.SetActive(false);
    }
    private void Update()
    {
        if (dogNear == true) 
        {
            Cat.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.enabled= true;
            CatHair.SetActive(true);
        }
        if (Cat.transform.position.z > 15)
        {
            Cat.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cat.transform.Rotate(0, 180, 0);
            dogNear = true;
        }
    }
}
