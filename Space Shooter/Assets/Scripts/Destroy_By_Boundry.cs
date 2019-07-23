using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_Boundry : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
