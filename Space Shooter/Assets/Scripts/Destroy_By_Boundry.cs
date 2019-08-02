using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Boundry : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Hitbox"))
        {
            return;                      
        }

        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
