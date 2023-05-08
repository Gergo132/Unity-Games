using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggernEnter(Collider other)
    {

        if (other.CompareTag("csont") || other.CompareTag("repa") || other.CompareTag("alma")) { Destroy(other.gameObject); }
        this.AddComponent<Animation>();


    }
}
