using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject[] animals;
    public TextMeshPro text;
    public TextMeshPro life;
    public TextMeshPro gover;
    public GameObject player;

    public int lives;

    void Start()
    {

        lives = 3;


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            InvokeRepeating("spawnAnimal", 1, 3);
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].GetComponent<MoveForward>().enabled = true;
                animals[i].AddComponent<Collision>();


            }
            text.enabled= false;
            life.text = "Lives: "+lives+" / 3";

            if (lives == 0) {;
                GameOver(); }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }
    }

    void spawnAnimal()
    {
        int idx = Random.Range(0, animals.Length);
        Instantiate(animals[idx], 
            new Vector3(Random.Range(-15f,15f), 0.03f, 17),
            animals[idx].transform.rotation);
    }

    public void GameOver()
    {
        gover.text = "GameOver!";

    }
    
}
