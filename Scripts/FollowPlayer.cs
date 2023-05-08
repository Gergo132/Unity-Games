using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    bool playerChosen = false;

    public void Setup(GameObject player)
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        this.player = player;
        playerChosen = true;
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        if (playerChosen)
        {
            transform.position = player.transform.position + offset; 
        }

    }
}
