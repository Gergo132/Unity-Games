using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    bool isGrounded = true;
    public int jumpCount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 3f;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, 0 ,verticalInput) * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true || jumpCount < 2))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isGrounded = false;
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
