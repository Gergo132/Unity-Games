using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public TextMeshProUGUI dialogBox;
    private void Start()
    {
        dialogBox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.enabled = true;
            Debug.Log("dialogBox on!");
        }
        else
        {
            dialogBox.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.enabled = false;
            Debug.Log("dialogBox off!");
        }
    }



}
