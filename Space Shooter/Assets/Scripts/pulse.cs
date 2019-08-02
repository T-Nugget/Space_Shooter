using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse : MonoBehaviour
{
    public float value = 1f;
 

     private void Update()
     {
        Vector3 temp = transform.localScale; 

        temp.x = value;
        temp.y = value;
        temp.z = value;
 
        transform.localScale = temp;
    }
}

