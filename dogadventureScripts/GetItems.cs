using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItems : MonoBehaviour
{
    public int FlowerCount;
    public int CatHairCount;
    public GameObject CatHair;
    public GameObject Potion;
    public bool gotPotion = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flower"))
        {
            FlowerCount++;
            Debug.Log("Number of Flowers: " + FlowerCount);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("CatHair"))
        {
            CatHairCount++;
            Debug.Log("Player got the Cathair");
            CatHair.SetActive(false);
        }

        if (FlowerCount > 2 && CatHairCount > 0)
        {
            gotPotion = true;
            Potion.SetActive(true);
        }
        /* ez valamiért nem mûködik :/
        if (gotPotion = true && Input.GetKeyDown(KeyCode.C))
        {
            Potion.SetActive(true);
        }
        */
    }
}
