using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=10;
    public GameObject food;
    public GameObject bone;
    public GameObject apple;
    public GameObject carrot;
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && transform.position.x < 19)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -19)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

                Instantiate(bone,
                    transform.position + new Vector3(0, 2, 0),
                    bone.transform.rotation);
            bone.AddComponent<MoveForward>();
            bone.gameObject.tag = "csont";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {


                Instantiate(apple,
                    transform.position + new Vector3(0, 2, 0),
                    apple.transform.rotation);
            apple.AddComponent<MoveForward>();
            apple.gameObject.tag = "alma";

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

  
                Instantiate(carrot,
                    transform.position + new Vector3(0, 2, 0),
                    carrot.transform.rotation);
            carrot.AddComponent<MoveForward>();
            carrot.gameObject.tag = "repa";

        }
    }
}
