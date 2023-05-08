using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class gamemanager : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject player;
    public TextMeshProUGUI text;
    public TextMeshProUGUI timeText;
    public int timeLeft;

    private void Start()
    {
        timeText.SetText("time: " + timeLeft);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timeText.SetText("time: " + timeLeft);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToDisable.SetActive(false);
            player.GetComponent<playerController>().enabled = false;
            text.gameObject.SetActive(true);
        }
    }
}
